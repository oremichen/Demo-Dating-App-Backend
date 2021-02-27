using Dapper;
using EmployeeManagement.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.RoleRepository
{
    public class RoleRepo: IRoleRepo
    {
        private readonly ConnectionStrings _appSettings;

        public RoleRepo(IOptions<ConnectionStrings> options)
        {
            _appSettings = options.Value;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_appSettings.EmployeeConnection);
            }
        }

        public async Task<long> CreateRole(UserRoles roles)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[CreateRoles] @rolecode, @rolename, @passwordhash, @passwordsalt";
                var result = await conn.ExecuteScalarAsync<long>(sql, new
                {
                   roles.RoleCode,
                   roles.RoleName,
                   roles.PasswordHash,
                   roles.PasswordSalt
                });
                return result;
            }
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetAllRoles]";
                var result = await conn.QueryAsync<Roles>(sql);
                return result;
            }
        }

        public async Task<Roles> GetRolesById(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetRoleByRoleId] @roleId";
                var result = await conn.QueryFirstOrDefaultAsync<Roles>(sql, new
                {
                    id
                });
                return result;
            }
        }

        public async Task<Roles> UpdateRole(Roles roles)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[UpdateRoles] @roleid, @rolecode, @rolename";
                var result =  conn.ExecuteScalarAsync<Roles>(sql, new
                {
                    roles.RoleId,
                    roles.RoleCode,
                    roles.RoleName
                });
                return await result;
            }
        }

        public async Task DeleteRole(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[DeleteRole] @roleid";
                var result = conn.ExecuteScalarAsync(sql, new
                {
                   id
                });
                await Task.CompletedTask;
            }
        }

        public async Task<Roles> GetUserByRoleName(string name)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetRoleByName] @name";
                var result = await conn.QueryFirstOrDefaultAsync<Roles>(sql, new
                {
                    name
                });
                return result;
            }
        }
    }
}
