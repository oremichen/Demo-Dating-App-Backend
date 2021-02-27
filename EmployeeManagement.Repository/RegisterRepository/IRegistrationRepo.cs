using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.RegisterRepository
{
    public interface IRegistrationRepo
    {
        Task<long> CreateUserRegistration(Registration model);
        Task<IEnumerable<Registration>> GetRegisteredAllUser();
        Task<Registration> GetRegisteredUserByEmail(string email);
    }
}
