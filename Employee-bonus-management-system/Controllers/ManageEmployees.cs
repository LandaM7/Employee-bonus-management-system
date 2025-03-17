using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.AspNetCore.Authorization;
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

		[Authorize(Roles = "Admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetEmployeeById(string id)
		{
			var employees = await _employeeService.GetEmployeeByIdAsync(id);
			return Ok(employees);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("add")]
		public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employee)
		{
			await _employeeService.AddEmployeeAsync(employee);
			return Ok("Employee added successfully!");
		}


		[Authorize(Roles = "Admin")]
		[HttpGet("admin-only")]
		public IActionResult GetAdminData()
		{
			return Ok("This is protected data for Admins only.");
		}

		[Authorize(Roles = "Employee")]
		[HttpGet("employee-only")]
		public IActionResult GetEmployeeData()
		{
			return Ok("This is protected data for Employees only.");
		}


	}
}
