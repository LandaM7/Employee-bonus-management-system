using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Infrastructure.Repositories.Interfaces;

namespace EmployeeBonusManagement.Infrastructure.Repositories
{
	public class EmployeeRepository<T>  : IEmployeeRepository<EmployeeDto>
	{
		private readonly IDbConnection _dbConnection;

		public EmployeeRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
		{
			string sql = @" SELECT u.Id, u.FirstName, u.LastName, u.Salary, u.Email, r.UserName, 
							u.DateOfBirth, u.HireDate AS Role 
				            FROM AspNetUsers u
				            LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
				            LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id;";

			return await _dbConnection.QueryAsync<EmployeeDto>(sql);
		}
	}
}
