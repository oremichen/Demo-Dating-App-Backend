using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.RegisterRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.RegistrationAppService
{
    public class RegistrationAppServices : IRegistrationAppServices
    {
        private readonly IRegistrationRepo _registrationRepo;
        private readonly IMapper _mapper;

        public RegistrationAppServices(IRegistrationRepo registrationRepo, IMapper mapper)
        {
            _registrationRepo = registrationRepo;
            _mapper = mapper;
        }

        public async Task<long> CreateUserRegistration(RegistrationDto model)
        {
            try
            {
                var registeredUser = _mapper.Map<Registration>(model);
                var insertUser = await _registrationRepo.CreateUserRegistration(registeredUser);
                return insertUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<IEnumerable<Registration>> GetRegisteredAllUser()
        {
            try
            {
                var getAllRegisteredUser = await _registrationRepo.GetRegisteredAllUser();
                return getAllRegisteredUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Registration> GetRegisteredUserByEmail(string email)
        {
            try
            {
                var getUser = await _registrationRepo.GetRegisteredUserByEmail(email);
                return getUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
