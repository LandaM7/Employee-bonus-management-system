using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Application.DTOs
{
	public class DepartmentDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string CreateByUserId { get; set; }
		public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
}
