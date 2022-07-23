using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.TokenService
{
    public interface ITokenServices
    {
        Task<string> CreateToken(Users user);
    }
}
