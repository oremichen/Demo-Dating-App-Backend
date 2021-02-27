using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.RegistrationAppService
{
    public interface IRegistrationAppServices
    {
        Task<long> CreateUserRegistration(RegistrationDto model);
        Task<IEnumerable<Registration>> GetRegisteredAllUser();
        Task<Registration> GetRegisteredUserByEmail(string email);
    }
}
