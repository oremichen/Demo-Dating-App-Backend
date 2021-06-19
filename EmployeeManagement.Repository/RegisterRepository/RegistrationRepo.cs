using Dapper;
using EmployeeManagement.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.RegisterRepository
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly ConnectionStrings _appSettings;

        public RegistrationRepo(IOptions<ConnectionStrings> options)
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

        public async Task<long> CreateUserRegistration(Registration model)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[CreateUserRegistration] @name, @email, @passwordEncrypted, @password, @dateCreated, @DateOfBirth, @gender";
                var result = await conn.ExecuteScalarAsync<long>(sql, new
                {
                    model.Name,
                    model.Email,
                    model.PasswordEncrypted,
                    model.Password,
                    model.DateCreated,
                    model.DateOfBirth,
                    model.Gender
                });
                return result;
            }
        }

        public async Task<IEnumerable<Registration>> GetRegisteredAllUser()
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetAllRegisteredUsers]";
                var result = await conn.QueryAsync<Registration>(sql);
             
                return result;
            }
        }



        public async Task<Registration> GetRegisteredUserByEmail(string email)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetRegisteredUserByEmail] @email";
                var result = await conn.QueryFirstOrDefaultAsync<Registration>(sql, new
                {
                    email
                });

                return result;
            }
        }
    }
}
