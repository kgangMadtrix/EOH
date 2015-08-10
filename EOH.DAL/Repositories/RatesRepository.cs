using EOH.DAL.Interfaces;
using EOH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Repositories
{
    public class RatesRepository : RepositoryBase<Rate>, IRatesRepository
    {
        internal override DbSet<Rate> Table
        {
            get { return Context.Rates; }
        }

        public Rate SelectRateByValue(decimal rate)
        {
            return Context.Rates.Where(a => a.Amount.Equals(rate)).FirstOrDefault();
        }
    }
}
