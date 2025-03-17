using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EmployeeBonusManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EmployeeBonusManagement.Application.DTOs
{
    public class LoginDto
    {
	    public string Email { get; set; }
	    public string Password { get; set; }
	}

}
