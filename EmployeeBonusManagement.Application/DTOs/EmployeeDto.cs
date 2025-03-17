using EmployeeBonusManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Application.DTOs
{
	public  class EmployeeDto
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PersonalNumber { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime HireDate { get; set; }
		public string DepartmentId { get; set; }
		public int IsActive { get; set; }
		public decimal Salary { get; set; }
		public string? RecommenderEmployeeId { get; set; }
		public string Role { get; set; }
	}
}
