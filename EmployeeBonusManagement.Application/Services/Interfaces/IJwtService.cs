using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
    public interface IJwtService
    {
	    AuthResponse GenerateToken(ApplicationUser user, IList<string> roles);
	    string GenerateRefreshToken();
    }
}
