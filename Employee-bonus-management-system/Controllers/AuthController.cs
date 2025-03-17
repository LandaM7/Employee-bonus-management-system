using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Employee_bonus_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
	    private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}


		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
		{
			if (loginDto == null)
				return BadRequest("Invalid login request.");

			var result = await _authService.LoginAsync(loginDto);

			if (!result.Success)
			{
				// If login fails, return unauthorized or bad request with a message
				return Unauthorized(new { message = "Invalid email or password." });
			}

			if (!ModelState.IsValid)

				return BadRequest(ModelState);

			return Ok(result); // Return the AuthResponse if login is successful
		}
	}
}
