using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Core.Entities;

namespace EmployeeBonusManagement.Application.DTOs
{
    class LoginDto
    {
	    public string Email { get; set; }
	    public string Password { get; set; }
		public Role Role { get; set; }
	}

}
