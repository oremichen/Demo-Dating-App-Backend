using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.Helpers;
using EmployeeManagement.AppService.PasswordHelper;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.PhotoRepository;
using EmployeeManagement.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.UsersAppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;
        private readonly IPhotoRepository _photoRepository;

        public UserAppService(IUserRepo userRepo, IMapper mapper, ITokenServices tokenServices, IPhotoRepository photoRepository)
        {
            _userRepo = userRepo;
            _tokenServices = tokenServices;
            _mapper = mapper;
            _photoRepository = photoRepository;
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
                    DateCreated = user.DateCreated,
                    KnownAs = user.KnownAs,
                    DateOfBirth = user.DateOfBirth,
                    City = user.City,
                    Gender = user.Gender
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

        public async Task<PagedList<Members>> GetAllUsers(UserParams userParams)
        {
           
                var userList = await _userRepo.GetAllUsers();

                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                var filter = userList.AsQueryable().Where(x => x.Name != userParams.CurrentUserName & x.Gender == userParams.Gender
                & (x.DateOfBirth >= minDob & x.DateOfBirth <= maxDob));
                var listResults = filter.Select(s => new Members
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
                    LastAcvtive = s.LastActive,
                    LookingFor = s.LookingFor,
                    PhotoUrl = GetPhotoUrl(s.Id),
                    Photo =  this.GetUserPhotos(s.Id).ToList(),
                    
                });

                var memberList = await PagedList<Members>.CreateAsync(listResults, userParams.PageNumber, userParams.PageSize);

                return memberList;
           
        }

        public async Task<Members> GetUsersById(int id)
        {
            try
            {
                var result = await _userRepo.GetUsersById(id);

                var user = _mapper.Map<Members>(result);
               
                user.Photo = this.GetUserPhotos(id).ToList();
                user.PhotoUrl = GetPhotoUrl(id);
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

        public async Task<Users> UpdateUser(UpdateMembersDto member)
        {
            var updateUser = new Users();

            var getUser = await _userRepo.GetUsersById(member.Id);
            if (getUser != null)
            {
                var user = _mapper.Map(member, getUser);

                updateUser = await _userRepo.UpdateUsers(user);
            }
            else
            {
                updateUser = null;
            }

            return updateUser;
           
        }


        #region Helper methods
        public string GetPhotoUrl(int id)
        {
            var photo = this.GetMainPhotoByUserId(id);
            if (photo != null)
            {
                return photo.Url;
            }
            return null;
        }

        public IEnumerable<PhotoDto> GetUserPhotos(int userId)
        {
            var photos = _photoRepository.GetUserPhotos(userId);
            var photoList = GetPhotosHelper.GetPhotos(photos.ToList());
            return photoList;
        }

        public Photos GetMainPhotoByUserId(int id)
        {
            var photos = _photoRepository.GetUserPhotos(id);
            var getMainPhoto = photos.Where(r => r.IsMain == true).FirstOrDefault();
            return getMainPhoto;

        }

        #endregion
    }
}
