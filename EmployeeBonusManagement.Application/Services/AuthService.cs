using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeBonusManagement.Application.Services
{
    class AuthService
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthService(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			IConfiguration configuration,
			IHttpContextAccessor httpContextAccessor)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
		{

			var user = await _userManager.FindByEmailAsync(loginDto.Email);


			// Ensure user has Employee role
			if (!(await _userManager.IsInRoleAsync(user, "Employee")))
			{
				await _userManager.AddToRoleAsync(user, "Employee");
			}

			// Generate JWT & Refresh Token
			var token = GenerateJwtToken(user);
			var refreshToken = GenerateRefreshToken();
			user.RefreshToken = refreshToken;
			await _userManager.UpdateAsync(user);

			SetRefreshTokenCookie(refreshToken);


			if (user == null || !(await _userManager.CheckPasswordAsync(user, loginDto.Password)))
			{
				return new AuthResponse(success: false);
			}


			return new AuthResponse(success: true, accessToken: token, refreshToken: refreshToken,
				expiration: DateTime.UtcNow.AddDays(7), userEmail: loginDto.Email, roles: [loginDto.Role.ToString()]);
		}

		private void SetRefreshTokenCookie(string refreshToken)
		{
			var response = _httpContextAccessor.HttpContext.Response;
			response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = true, // Use only in production with HTTPS
				SameSite = SameSiteMode.Strict,
				Expires = DateTime.UtcNow.AddDays(7)
			});
		}

		private string GenerateJwtToken(ApplicationUser user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, user.UserName),
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(ClaimTypes.Role, "Employee")
		};

			var token = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		

		private string GenerateRefreshToken()
		{
			var refreshToken = Guid.NewGuid().ToString();

			return refreshToken;
		}
	}
}
