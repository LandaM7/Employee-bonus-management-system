using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;

namespace EmployeeBonusManagement.Application.Mapper;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		// Define your mappings here
		CreateMap<EmployeeDto, ApplicationUser>();  // Example mapping
		CreateMap<ApplicationUser, EmployeeDto>();  // Example reverse mapping
	}
}
