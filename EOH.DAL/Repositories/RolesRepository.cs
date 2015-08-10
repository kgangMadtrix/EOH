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
    public class RolesRepository : RepositoryBase<Role>, IRolesRepository
    {
        internal override DbSet<Role> Table
        {
            get { return Context.Roles; }
        }

        public Role SelectRoleByName(string roleName)
        {
            return Context.Roles.Where(a => a.Name.Equals(roleName)).FirstOrDefault();
        }

        public List<Role> GetRolesAndRates()
        {
            return Context.Roles.Include(r => r.Rate).ToList();
        }


        public List<Role> GetSearchedRolesAndRates(string search_Data)
        {
            return Context.Roles.Where(a => a.Name.ToLower().Contains(search_Data.ToLower())).Include(r => r.Rate).ToList();
        }


        public Role SelectByIDWithEmployees(int roleId)
        {
            return Context.Roles.Where(a => a.RoleId.Equals(roleId)).Include(e => e.Employees).FirstOrDefault();
        }
    }
}
