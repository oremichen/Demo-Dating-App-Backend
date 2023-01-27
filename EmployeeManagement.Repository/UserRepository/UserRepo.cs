using Dapper;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.IStorage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.UserRepository
{
    public class UserRepo : IUserRepo
    {
        private readonly ConnectionStrings _appSettings;
        private readonly IStorageRepo _storageRepo;

        public UserRepo(IOptions<ConnectionStrings> options, IStorageRepo storageRepo)
        {
            _appSettings = options.Value;
            _storageRepo = storageRepo;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_appSettings.EmployeeConnection);
            }
        }

        public async Task<long> Like(UserLike model)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[Like] @userId, @likedBy";
                var result = await conn.ExecuteScalarAsync<long>(sql, new
                {
                    model.UserId,
                    model.LikedBy
                });
                return result;
            }
        }

        public async Task<long> CreateUsers(Users model)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[CreateUsers] @name, @email, @passwordHash, @passwordSalt, @datecreated, @dateofbirth, @age, @knownas, @lastActive," +
                    $" @gender, @introduction, @lookingfor, @interests, @city";
                var result = await conn.ExecuteScalarAsync<long>(sql, new
                {
                    model.Name,
                    model.Email,
                    model.PasswordHash,
                    model.PasswordSalt,
                    model.DateCreated,
                    model.DateOfBirth,
                    model.Age,
                    model.KnownAs,
                    model.LastActive,
                    model.Gender,
                    model.Introduction,
                    model.LookingFor,
                    model.Interests,
                    model.City,
                  
                });
                return result;
            }
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetAllUsers]";
                var result = await conn.QueryAsync<Users>(sql);
                return result;
            }
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetUserByEmail] @email";
                var result = await conn.QuerySingleOrDefaultAsync<Users>(sql, new 
                {
                    email
                });
                return result;
            }
        }

        public async Task<Users> GetUsersById(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetUserById] @Id";
                var result = await conn.QueryFirstOrDefaultAsync<Users>(sql, new { id });
                return result;
            }
        }

        public async Task<Users> UpdateUsers(Users model)
        {
                using (var conn = Connection)
                {
                    var sql = $"[dbo].[UpdateUsers] @id, @name, @email, @passwordHash, @passwordSalt, @datecreated, @dateofbirth," +
                        $"@knownas, @lastactive, @gender, @introduction, @lookingfor, @interests, @city, @age";
                    var result = await conn.ExecuteScalarAsync<string>(sql, new
                    {
                        model.Id,
                        model.Name,
                        model.Email,
                        model.PasswordHash,
                        model.PasswordSalt,
                        model.DateCreated,
                        model.DateOfBirth,
                        model.KnownAs,
                        model.LastActive,
                        model.Gender,
                        model.Introduction,
                        model.LookingFor,
                        model.Interests,
                        model.City,
                        model.Age
                    });

                    return model;
                }

                       
        }
    }
}
