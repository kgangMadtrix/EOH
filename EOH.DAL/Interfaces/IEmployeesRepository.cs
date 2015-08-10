using EOH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Interfaces
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        Role SelectRoleByName(string roleName);

        Role SelectRoleById(int roleId);
    }
}
