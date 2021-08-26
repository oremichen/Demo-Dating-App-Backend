using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.UsersAppServices
{
    public interface IUserAppService
    {
        Task<UserDto> CreateUsers(CreateUsersDto user);
        Task<Users> UpdateUser(UpdateMembersDto member);
        Task<IEnumerable<Members>> GetAllUsers();
        Task<Members> GetUsersById(int id);
        Task<bool> CheckIfNameExist(string email);
        string GetPhotoUrl(int id);
    }
}
