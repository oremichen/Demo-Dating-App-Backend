using EmployeeManagement.AppService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.TokenService
{
    public interface ITokenServices
    {
        Task<string> CreateToken(CreateUsersDto user);
    }
}
