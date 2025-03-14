using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Application.DTOs
{
	public class BonusDto
	{
		public string Id { get; set; }
		public string EmployeeId { get; set; }
		public decimal Amount { get; set; }
		public DateTime BonusDate { get; set; }
		public string Reason { get; set; }
		public string CreateByUserId { get; set; }
	}
}
