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

		private readonly RoleManager<IdentityRole> _roleManager;

		public RoleSeederService(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task SeedRolesAsync()
		{
			string[] roleNames = { "AdminEmployee", "Employee" };

			foreach (var roleName in roleNames)
			{
				if (!await _roleManager.RoleExistsAsync(roleName))
				{
					await _roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}
		}
	}

}

