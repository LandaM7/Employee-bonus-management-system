using EmployeeBonusManagement.Core.Entities;
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
		Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
		Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
		Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
