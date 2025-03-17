using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Application.Services
{
    public class RoleAssignmentService :IRoleAssignmentService
    {
	    private readonly UserManager<ApplicationUser> _userManager;
	    private readonly RoleManager<ApplicationRoles> _roleManager;

	    public RoleAssignmentService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRoles> roleManager)
	    {
		    _userManager = userManager;
		    _roleManager = roleManager;
	    }

	    public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
	    {
		    var user = await _userManager.FindByIdAsync(userId);
		    if (user == null)
		    {
			    return false; 
		    }

		    if (!await _roleManager.RoleExistsAsync(roleName))
		    {
			    return false; 
		    }

		    var result = await _userManager.AddToRoleAsync(user, roleName);
		    return result.Succeeded;
	    }

	    public async Task<bool> RemoveRoleFromUserAsync(string userId, string roleName)
	    {
		    var user = await _userManager.FindByIdAsync(userId);
		    if (user == null)
		    {
			    return false;
		    }

		    if (!await _roleManager.RoleExistsAsync(roleName))
		    {
			    return false;
		    }

		    var result = await _userManager.RemoveFromRoleAsync(user, roleName);
		    return result.Succeeded;
	    }
	}

}
