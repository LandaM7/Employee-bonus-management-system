using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Application.Services
{
	public class RoleSeederService
	{
		private readonly RoleManager<ApplicationRoles> _roleManager;

		public RoleSeederService(RoleManager<ApplicationRoles> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task SeedRolesAsync()
		{
			var roleNames = Enum.GetValues(typeof(Role))
				.Cast<Role>()
				.Select(r => r.ToString())
				.ToArray();

			foreach (var roleName in roleNames)
			{
				if (!await _roleManager.RoleExistsAsync(roleName))
				{
					var roleEnum = Enum.Parse<Role>(roleName); // Convert string back to enum
					await _roleManager.CreateAsync(new ApplicationRoles(roleEnum));
				}
			}
		}
	}

}

