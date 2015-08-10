using EOH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Interfaces
{
    public interface IRatesRepository : IRepository<Rate>
    {
        Rate SelectRateByValue(decimal rate);
    }
}
