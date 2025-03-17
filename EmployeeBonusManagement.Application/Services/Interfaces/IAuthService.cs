using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
    interface IAuthService
    {
	    Task<AuthResponse> LoginAsync(LoginDto loginDto);
	    Task<AuthResponse> RefreshTokenAsync(string refreshToken);
	    Task LogoutAsync();
	}
}
