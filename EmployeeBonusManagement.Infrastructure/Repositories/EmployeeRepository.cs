using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Infrastructure.Repositories
{
	public class EmployeeRepository : IEmployeeRepository<ApplicationUser> 

	{
	private readonly IDbConnection _dbConnection;
	private readonly UserManager<ApplicationUser> _userManager;



	public EmployeeRepository(IDbConnection dbConnection , UserManager<ApplicationUser> userManager)
	{
		_dbConnection = dbConnection;
		_userManager = userManager;

	}

	public async Task<IEnumerable<ApplicationUser>> GetAllEmployeesAsync()
	{
		string sql = @" SELECT u.Id,r.[Name], u.FirstName, u.LastName, u.Salary, u.Email,  
							u.DateOfBirth, u.HireDate AS Role 
				            FROM AspNetUsers u
				            LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
				            LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id;";

		return await _dbConnection.QueryAsync<ApplicationUser>(sql);
	}

	public async Task<ApplicationUser> GetUserByEmailAsync(string email)
	{
		return await _userManager.FindByEmailAsync(email.ToLower());
	}

	public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
	{
		return await _userManager.CheckPasswordAsync(user, password);
	}

	public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
	{
		return await _userManager.GetRolesAsync(user);
	}
	}
}
