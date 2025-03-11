using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Core.Entities
{
    public class Bonus
    {
	   public string Id { get; set; }
	   [ForeignKey("Id")]
	   public string EmployeeId { get; set; }
	   public decimal Amount { get; set; }
	   public DateTime BonusDate { get; set; }
	   public string  Reason { get; set;}
	   [ForeignKey("Id")]
	   public string CreateByUserId { get; set;  }
    }
}
