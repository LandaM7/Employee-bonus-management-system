using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBonusManagement.Infrastructure.Data
{
	public class AuthDbContext : IdentityDbContext<ApplicationUser>
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
		{}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Custom properties for ApplicationUser
			builder.Entity<ApplicationUser>(entity =>
			{
				entity.Property(e => e.FirstName).HasMaxLength(100);
				entity.Property(e => e.LastName).HasMaxLength(100);
				entity.Property(e => e.PersonalNumber).HasMaxLength(50); // Set length for PersonalNumber if needed
				entity.Property(e => e.DateOfBirth).HasColumnType("datetime2"); // Set the column type for DateOfBirth
				entity.Property(e => e.HireDate).HasColumnType("datetime2"); // Same for HireDate
				entity.Property(e => e.DepartmentId).HasMaxLength(50); // Set length for DepartmentId if needed

				// Optional: You can add other custom configurations (like indexes, etc.)
			});
		}
	}
}
	

