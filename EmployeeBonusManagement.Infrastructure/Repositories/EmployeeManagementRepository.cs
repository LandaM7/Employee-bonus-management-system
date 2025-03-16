using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.DTOs;
using EmployeeBonusManagement.Core.Interfaces;
using EmployeeBonusManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBonusManagement.Infrastructure.Repositories
{
    public class EmployeeManagementRepository<T>  : IEmployeeManagementRepository<T>    where T: class
    {
	    private readonly AuthDbContext _context;
	    private readonly DbSet<T> _dbSet;

	    public EmployeeManagementRepository(AuthDbContext context)
	    {
		    _context = context;
		    _dbSet = context.Set<T>();
	    }

	    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
	    public async Task UpdateAsync(T entity) => _dbSet.Update(entity);
	    public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
	    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
	}
}
