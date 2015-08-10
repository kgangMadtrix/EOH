using EOH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Interfaces
{
    public interface IRolesRepository : IRepository<Role>
    {

        Role SelectRoleByName(string roleName);

        List<Role> GetRolesAndRates();

        List<Role> GetSearchedRolesAndRates(string search_Data);

        Role SelectByIDWithEmployees(int roleId);
    }
}
