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


namespace EmployeeBonusManagement.Application.Services
{
    public class ManageEmployeesService : IEmployeeService<EmployeeDto>
    {
	    private readonly IUnitOfWork _unitOfWork;
	    private readonly IMapper _mapper;

	    public ManageEmployeesService(IUnitOfWork unitOfWork, IMapper mapper)
	    {
		    _unitOfWork = unitOfWork;
		    _mapper = mapper;
	    }

	    public async Task AddEmployeeAsync(EmployeeDto employeeDto)
	    {
		    var employee = _mapper.Map<ApplicationUser>(employeeDto); // Convert DTO → Entity
		    await _unitOfWork.Employees.AddAsync(employee);
		    await _unitOfWork.CompleteAsync();
	    }

	    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
	    {
		    var employees = await _unitOfWork.Employees.GetAllAsync();
		    return _mapper.Map<IEnumerable<EmployeeDto>>(employees); // Convert Entity → DTO
	    }
	}



}
