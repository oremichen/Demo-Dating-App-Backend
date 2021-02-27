using EmployeeManagement.AppService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.UsersAppServices
{
    public interface IUserAppService
    {
        Task<UserDto> CreateUsers(CreateUsersDto user);
        Task<IEnumerable<UsersDto>> GetAllUsers();
        Task<UsersDto> GetUsersById(int id);
        Task<bool> CheckIfNameExist(string email);
    }
}
