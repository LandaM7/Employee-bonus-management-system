using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Application.Interfaces;

namespace EmployeeBonusManagement.Application.Services
{
    public class ManageEmployeesService : IEmployeeService
    {
		private readonly IEmployeeRepository<EmployeeDto> _employeeRepository;

		public ManageEmployeesService(IEmployeeRepository<EmployeeDto> employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
		{
			return await _employeeRepository.GetAllAsync();
		}
	}
}
