using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.UserRepository
{
    public interface IUserRepo
    {
        Task<long> CreateUsers(Users user);
        Task<Users> UpdateUsers(Users user);
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUsersById(int id);
        Task<Users> GetUserByEmail(string email);
        Task<UserLike> Like(UserLike model);
        Task<UserLike> GetUserLike(int userId, int likedBy);
        Task<IEnumerable<Users>> GetUserLikes(string predicate, int id);
        Task<Users> GetUserWithLike(int id);
    }
}
