using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.Helpers;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.UsersAppServices
{
    public interface IUserAppService
    {
        Task<UserDto> CreateUsers(CreateUsersDto user);
        Task<Users> UpdateUser(UpdateMembersDto member);
        Task<PagedList<Members>> GetAllUsers(UserParams userParams);
        Task<Members> GetUsersById(int id);
        Task<bool> CheckIfNameExist(string email);
        string GetPhotoUrl(int id);
        Task<long> Like(int userId, int likedBy);
        Task<List<LikeDto>> GetUserLikes(string predicate, int id);
        Task<Users> GetUserWithLike(int id);
        Task<UserLike> GetUserLike(int userId, int likeById);
    }
}
