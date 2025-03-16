using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Core.Interfaces;
using EmployeeBonusManagement.Infrastructure.Data;
using EmployeeBonusManagement.Infrastructure.Repositories;

namespace EmployeeBonusManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork  : IUnitOfWork
    {
	    private readonly AuthDbContext _context;

	    public IEmployeeManagementRepository<ApplicationUser> Employees { get; }  // Use Entity

	    public UnitOfWork(AuthDbContext context)
	    {
		    _context = context;
		    Employees = new EmployeeManagementRepository<ApplicationUser>(context); // Use Employee entity
	    }

	    public async Task<int> CompleteAsync()
	    {
		    return await _context.SaveChangesAsync();
	    }

	    public void Dispose()
	    {
		    _context.Dispose();
	    }

	}
}
