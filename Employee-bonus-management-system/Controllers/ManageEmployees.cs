using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_bonus_management_system.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService<EmployeeDto> _employeeService;

		public EmployeesController(IEmployeeService<EmployeeDto> employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _employeeService.GetAllEmployeesAsync();
			return Ok(employees);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employee)
		{
			await _employeeService.AddEmployeeAsync(employee);
			return Ok("Employee added successfully!");
		}
	}
}
