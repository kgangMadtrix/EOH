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
    public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        internal override DbSet<Employee> Table
        {
            get { return Context.Employees; }
        }
        public Role SelectRoleByName(string roleName)
        {
            return Context.Roles.Where(a => a.Name.Equals(roleName)).FirstOrDefault();
        }

        public Role SelectRoleById(int roleId)
        {
            return Context.Roles.Where(a => a.RoleId.Equals(roleId)).FirstOrDefault();
        }

    }

}
