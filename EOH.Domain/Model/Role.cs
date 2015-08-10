using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.Domain.Model
{
    public class Role
    {
        public Role()
        {
            Employees = new List<Employee>();
        }
        [Key]
        public int RoleId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        public virtual IList<Employee> Employees { get; set; }
        [Display(Name = "Rate Amount")]
        public int? RateId { get; set; }
        [Display(Name = "Rate Amount")]
        public virtual Rate Rate { get; set; }
    }
}

