using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.RoleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.RolesAppServices
{
    public class RolesAppService : IRolesAppService
    {
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;

        public RolesAppService(IRoleRepo roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }

        public async Task<long> CreateNewUserRole(CreateRolesDto roles)
        {
            try
            {

                using var hmac = new HMACSHA512();
                var createRole = new UserRoles
                {
                    RoleName = roles.RoleName.ToLower(),
                    RoleCode = "A",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(roles.Password)),
                    PasswordSalt = hmac.Key
                };
               // var role = _mapper.Map<Roles>(createRole);
                var roleId = await _roleRepo.CreateRole(createRole);

                return roleId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RolesDto>> GetAllRoles()
        {
            try
            {
                var roleList = await _roleRepo.GetAllRoles();

                var roles = roleList.AsQueryable().Select(s => new RolesDto
                {
                    RoleName = s.RoleName,
                    RoleCode = s.RoleCode

                }).ToList();

                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Roles> GetRolesById(int id)
        {
            try
            {
                var role = await _roleRepo.GetRolesById(id);
                
                return role;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Roles> UpdateUserRole(Roles roles)
        {
            try
            {
                var updatedRole = await _roleRepo.UpdateRole(roles);

                return updatedRole;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUserRole(int id)
        {
            try
            {
                 await _roleRepo.DeleteRole(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CheckIfNameExist(string name)
        {
            try
            {
                bool doesExist = false;
                var exist = await _roleRepo.GetUserByRoleName(name);
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
