using Dapper;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.Data;
using EmployeeManagement.Repository.IStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.UserRepository
{
    public class UserRepo : IUserRepo
    {
        private readonly ConnectionStrings _appSettings;
        private readonly DataContext _dataContext;

        public UserRepo(IOptions<ConnectionStrings> options, DataContext dataContext)
        {
            _appSettings = options.Value;
            _dataContext = dataContext;
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
            var userLike = await _dataContext.UserLike.AddAsync(model);
            return userLike.Entity.Id;
        }

        public async Task<UserLike> GetUserLike(int userId, int likedBy)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetUserLikeByUserIdLikedBy] @userId, @likedBy";
                var result = await conn.QuerySingleOrDefaultAsync<UserLike>(sql, new
                {
                    userId,
                    likedBy
                });
                return result;
            }
        }

        public async Task<Users> GetUserWithLike(int id)
        {
            using (var conn = Connection)
            {
                var sql = $"[dbo].[GetUserWithLike] @id";
                var result = await conn.QuerySingleOrDefaultAsync<Users>(sql, new
                {
                    id
                });
                return result;
            }
        }

        public async Task<IEnumerable<Users>> GetUserLikes(string predicate, int id)
        {
            string sql = "";
            using (var conn = Connection)
            { 
                if(predicate == "liked") { sql = $"[dbo].[GetAllUserLiked] @id"; }
                if (predicate == "likedBy") { sql = $"[dbo].[GetAllUserLikedBy] @id"; }
                var result = await conn.QueryAsync<Users>(sql, new { id });
                return result;
            }
        }



        public async Task<long> CreateUsers(Users model)
        {
            var user = await _dataContext.Users.AddAsync(model);
            return user.Entity.Id;
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Users> GetUsersById(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<Users> UpdateUsers(Users model)
        {
            var user = _dataContext.Users.Update(model);
            return user.Entity;        
        }
    }
}
