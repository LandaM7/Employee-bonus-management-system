using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Core.Entities
{
	public class ApplicationRoles : IdentityRole
	{
		public Role RoleType { get; set; } = Role.User; // ✅ Set a default value

		public ApplicationRoles() : base() { } // ✅ Required for EF Core

		public ApplicationRoles(Role role) : base(role.ToString())
		{
			RoleType = role;
		}
	}

	public enum Role
	{
		User,
		Admin
	}



}