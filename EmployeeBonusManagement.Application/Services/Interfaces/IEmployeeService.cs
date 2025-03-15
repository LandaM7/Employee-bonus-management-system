using EmployeeBonusManagement.Application.DTOs;

namespace EmployeeBonusManagement.Application.Services.Interfaces
{
	public interface IEmployeeService<T> where T:class
	{
		public  Task<IEnumerable<T>> GetAllEmployeesAsync();
	}
}