using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Core.Interfaces;
using EmployeeBonusManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;


namespace EmployeeBonusManagement.Application.Services
{
    public class ManageEmployeesService : IEmployeeService<EmployeeDto>
    {
	    private readonly IUnitOfWork _unitOfWork;
	    private readonly IMapper _mapper;
	    private readonly UserManager<ApplicationUser> _userManager;
		private readonly IJwtService _jwtService;
		private readonly RoleAssignmentService _roleAssignmentService;

		public ManageEmployeesService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager ,  IJwtService jwtService , RoleAssignmentService roleAssignmentService)
	    {
		    _unitOfWork = unitOfWork;
		    _mapper = mapper;
		    _userManager = userManager;
		    _jwtService = jwtService;
		    _roleAssignmentService = roleAssignmentService;

	    }

	    public async Task AddEmployeeAsync(EmployeeDto employeeDto)
	    {
			Console.WriteLine($"employeeDto.isActive: {employeeDto.IsActive}, employeeDto.salary: {employeeDto.Salary}");

			var employee = _mapper.Map<ApplicationUser>(employeeDto);

			Console.WriteLine($"employee.IsActive: {employee.IsActive}, employee.Salary: {employee.Salary}");


			employee.NormalizedEmail = employee.Email.ToUpper();

		    var hashedPassword = _userManager.PasswordHasher.HashPassword(employee, employeeDto.Password);
		    employee.PasswordHash = hashedPassword;

		    var refreshToken = _jwtService.GenerateRefreshToken();
		    employee.RefreshToken = refreshToken;

		    var result = await _userManager.CreateAsync(employee, employeeDto.Password);

		    if (result.Succeeded)
		    {
			    await _roleAssignmentService.AssignRoleToUserAsync(employee.Id, "User");
			    if (employeeDto.Role == Role.Admin.ToString())
			    {
				    await _roleAssignmentService.AssignRoleToUserAsync(employee.Id, "Admin");
			    }
			    try
			    {
				    var saveResult = await _unitOfWork.CompleteAsync();
				    Console.WriteLine("CompleteAsync result: {saveResult}"); // Log the result
				    if (saveResult > 0)
				    {
					    Console.WriteLine("User added successfully.");
				    }
				    else
				    {
						// TODO somtimes does not add user
					    Console.WriteLine("CompleteAsync returned 0, user might not have been saved.");
				    }
			    }
			    catch (Exception ex)
			    {
				    Console.WriteLine("Error saving user: {ex.Message}");
				    Console.WriteLine( "Exception details: {ex}"); // Log the full exception\.
			    }
		    }
			else
			{
				foreach (var error in result.Errors)
				{
					Console.WriteLine($"Error Code: {error.Code}, Description: {error.Description}");
				}
			}
		}
		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
	    {
		    var employees = await _unitOfWork.Employees.GetAllAsync();
		    return _mapper.Map<IEnumerable<EmployeeDto>>(employees); // Convert Entity → DTO
	    }

	    public async Task<EmployeeDto> GetEmployeeByIdAsync(string id)
	    {
		    var employee = await _unitOfWork.Employees.GetByIdAsync(id);  // Get entity by id
		    return _mapper.Map<EmployeeDto>(employee);  // Map entity to DTO
	    }
	}



}
