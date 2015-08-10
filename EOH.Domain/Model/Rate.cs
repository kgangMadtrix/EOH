using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.Domain.Model
{
    public class Rate
    {
        public int RateId { get; set; }

        [Display(Name = "Rate Amount")]
        public decimal Amount { get; set; }
    }
}
