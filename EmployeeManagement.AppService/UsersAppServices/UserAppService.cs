using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.PasswordHelper;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.UsersAppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public UserAppService(IUserRepo userRepo, IMapper mapper, ITokenServices tokenServices)
        {
            _userRepo = userRepo;
            _tokenServices = tokenServices;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUsers(CreateUsersDto user)
        {
            try
            {
                var passwdsalt = EncryptPassword.CreateSalt(5);
                var passwd = EncryptPassword.GenerateSHAHash(user.Password, passwdsalt);

                var users = new Users
                {
                    Name = user.Name,
                    Email = user.Email,
                    PasswordHash = passwd,
                    PasswordSalt = passwdsalt,
                    DateCreated = user.DateCreated
                };
                var userId = await _userRepo.CreateUsers(users);

                //create token
                var token = await _tokenServices.CreateToken(user);

                return new UserDto
                {
                    Id = (int)userId,
                    Name = user.Name,
                    Email = user.Email,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Members>> GetAllUsers()
        {
            try
            {
                var userList = await _userRepo.GetAllUsers();

                var ListResults = userList.AsQueryable().Select(s => new Members
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    DateCreated = s.DateCreated,
                    Age = s.Age,
                    City = s.City,
                    DateOfBirth = s.DateOfBirth,
                    Gender = s.Gender,
                    Interests = s.Interests,
                    Introduction = s.Introduction,
                    KnownAs = s.KnownAs,
                    LastAcvtive = s.LastAcvtive,
                    LookingFor = s.LookingFor,
                    

                }).ToList();

                return ListResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Members> GetUsersById(int id)
        {
            try
            {
                var result = await _userRepo.GetUsersById(id);

                var user = _mapper.Map<Members>(result);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckIfNameExist(string email)
        {
            try
            {
                bool doesExist = false;
                var exist = await _userRepo.GetUserByEmail(email);
                if (exist == null)
                {
                    return doesExist;
                }
                doesExist = true;
                return doesExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
