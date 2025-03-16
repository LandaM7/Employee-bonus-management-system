using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Core.Entities
{
    public class Department
    {
	    public string Id { get; set; }
		public string Name { get; set; }
	    [ForeignKey("Id")]
	    public string CreateByUserId { get; set; }
	    public DateTime CreateDate { get; set; }
	    public int IsActive { get; set; }
	    
	}
}
