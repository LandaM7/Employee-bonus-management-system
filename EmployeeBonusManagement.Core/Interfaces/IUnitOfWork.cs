using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Core.Entities;
using EmployeeBonusManagement.Core.Interfaces;

namespace EmployeeBonusManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
	    IEmployeeManagementRepository<ApplicationUser> Employees { get; }
	    Task<int> CompleteAsync();
	}
}
