using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
	public interface IEmployeeService<T>
	{
		Task AddEmployeeAsync(EmployeeDto employeeDto);
		Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
	}
}