using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
		// id , email , username and password already exists in Identity 

	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public string PersonalNumber { get; set; }
	    public DateTime DateOfBirth { get; set; }
	    public DateTime HireDate { get; set; }
	    public string DepartmentId { get; set; }
	    public int IsActive { get; set; }
		public decimal Salary { get; set; }
	    

	    public string? RecommenderEmployeeId { get; set; }
	    [ForeignKey("RecommenderEmployeeId")]
	    public ApplicationUser? RecommenderEmployee { get; set; }

	    public string RefreshToken { get; set; }

	}
}
