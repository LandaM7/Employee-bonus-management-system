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

namespace EmployeeBonusManagement.Infrastructure.Repositories
{
	public class EmployeeRepository<T> : IEmployeeRepository<T> where T : class

	{
	private readonly IDbConnection _dbConnection;

	public EmployeeRepository(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}

	public async Task<IEnumerable<T>> GetAllEmployeesAsync()
	{
		string sql = @" SELECT u.Id,r.[Name], u.FirstName, u.LastName, u.Salary, u.Email,  
							u.DateOfBirth, u.HireDate AS Role 
				            FROM AspNetUsers u
				            LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
				            LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id;";

		return await _dbConnection.QueryAsync<T>(sql);
	}
	}
}
