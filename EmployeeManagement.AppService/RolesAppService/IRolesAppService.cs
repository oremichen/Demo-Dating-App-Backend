using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.RolesAppServices
{
    public interface IRolesAppService
    {
        Task<long> CreateNewUserRole(CreateRolesDto roles);
        Task<Roles> UpdateUserRole(Roles roles);
        Task<bool> DeleteUserRole(int id);

        Task<IEnumerable<RolesDto>> GetAllRoles();
        Task<bool> CheckIfNameExist(string name);
    }
}
