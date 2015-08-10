using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.Domain.Model
{
    public class Employee
    {
        public Employee()
        {
            Roles = new List<Role>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "ID Number")]
        [StringLength(13)]
        [RegularExpression("(?<Year>[0-9][0-9])(?<Month>([0][1-9])|([1][0-2]))(?<Day>([0-2][0-9])|([3][0-1]))(?<Gender>[0-9])(?<Series>[0-9]{3})(?<Citizenship>[0-9])(?<Uniform>[0-9])(?<Control>[0-9])", ErrorMessage = "Invalid ID Number")]
        public string IdNumber { get; set; }
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        [StringLength(50)]
        public string Surname { get; set; }


        public string FullName
        {
            get { return Name + " " + Surname; }
        }
        


        public virtual IList<Role> Roles { get; set; }
    }
}
