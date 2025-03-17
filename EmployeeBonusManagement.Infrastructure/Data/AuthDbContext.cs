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
	public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRoles, string>
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Custom properties for ApplicationUser
			builder.Entity<ApplicationUser>(entity =>
			{
				entity.Property(e => e.FirstName).HasMaxLength(100);
				entity.Property(e => e.LastName).HasMaxLength(100);
				entity.Property(e => e.PersonalNumber).HasMaxLength(50);
				entity.Property(e => e.DateOfBirth).HasColumnType("datetime2");
				entity.Property(e => e.HireDate).HasColumnType("datetime2");
				entity.Property(e => e.DepartmentId).HasMaxLength(50);


				entity.Property(u => u.NormalizedEmail).HasMaxLength(256);
				entity.Property(u => u.NormalizedUserName).HasMaxLength(256);


				entity.Property(e => e.IsActive).HasColumnType("Int");
				entity.Property(e => e.Salary).HasColumnType("DECIMAL(10,2)");

				entity.Property(e => e.RefreshToken).HasColumnType("NVARCHAR(MAX)");

				builder.Entity<ApplicationRoles>(entity =>
				{
					entity.Property(e => e.RoleType)
						.HasConversion<string>() // Convert Enum to string in DB
						.IsRequired() // Ensure it is not nullable
						.HasDefaultValue(Role.User);
				});

				builder.Entity<ApplicationRoles>().HasData(
					new ApplicationRoles
					{
						Id = "B2A0E6F1-1E30-4D4B-97E1-5B3F0A5D6A10",
						Name = "Admin",
						NormalizedName = "ADMIN",
						RoleType = Role.Admin
					},
					new ApplicationRoles
					{
						Id = "D3C1F7A2-2F41-5E5C-88F2-6C4G1B6E7B21",
						Name = "User",
						NormalizedName = "USER",
						RoleType = Role.User
					});

			});
		}
	}
}

	

