using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Core.Interfaces
{
	public interface IEmployeeManagementRepository<T> where T: class
    {
	    Task AddAsync(T entity);
	    Task UpdateAsync(T entity);
	    Task DeleteAsync(T entity);
	    Task<IEnumerable<T>> GetAllAsync();
	}
}
