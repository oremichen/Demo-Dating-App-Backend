using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.RoleRepository
{
    public interface IRoleRepo
    {
        Task<long> CreateRole(UserRoles roles);
        Task<Roles> UpdateRole(Roles roles);
        Task DeleteRole(int id);

        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRolesById(int id);
        Task<Roles> GetUserByRoleName(string name);
    }
}
