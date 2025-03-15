using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Core.Interfaces
{
    interface IRepository<T> where T : class
    {

	    Task<T> GetByIdAsync(string id);
	    Task SaveChangesAsync();
		// ესენი ალბათ აქ არ დაგვჭირდება 
		//Task<IEnumerable<T>> GetAllAsync();
		//Task AddAsync(T entity);
		//void Update(T entity);
		//void Delete(T entity);


	}
}
