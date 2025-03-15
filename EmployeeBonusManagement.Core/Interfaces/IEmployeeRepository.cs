using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Core.Interfaces
{
    public interface IEmployeeRepository<T> where T : class
    {
		Task<IEnumerable<T>> GetAllEmployeesAsync();
	}
}
