using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.PasswordHelper;
using EmployeeManagement.AppService.PhotoAppService;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.PhotoRepository;
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

                var listResults = userList.AsQueryable().Select(s => new Members
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
                    
                }).ToList();

                return listResults;
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
                //var user = new Users()
                //{
                //    Id = getUser.Id,
                //    DateCreated = DateTime.Now,
                //    DateOfBirth = member.DateOfBirth,
                //    City = member.City,
                //    Email = getUser.Email,
                //    Gender = member.Gender,
                //    Interests = member.Interests,
                //    Introduction = member.Introduction,
                //    KnownAs = member.KnownAs,
                //    LastActive = DateTime.Now,
                //    LookingFor = member.LookingFor,
                //    Name = member.Name,
                //    PasswordHash = getUser.PasswordHash,
                //    PasswordSalt = getUser.PasswordSalt
                //};

                var user = _mapper.Map(member, getUser);

                updateUser = await _userRepo.UpdateUsers(user);

                //insert user photos
                //await this.InsertUserPhotos(member);
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
            return photo.Result.Url;
        }

        public async Task InsertUserPhotos(MembersDto model)
        {

            var photos = new List<Photos>();
            var photo = new Photos();

            if (model.Photo.Count > 0)
            {
                foreach (var itemPhoto in model.Photo)
                {
                    photo.IsMain = itemPhoto.IsMain;
                    photo.PublicId = itemPhoto.PublicId;
                    photo.Url = itemPhoto.Url;
                    photo.UserId = model.Id;

                    photos.Add(photo);

                }

                await _photoRepository.InsertPhotos(photos);
            }

        }

        //public async Task UpdateUserPhotos(UpdateMembersDto model)
        //{

        //    var photos = new List<Photos>();
        //    var photo = new Photos();

        //    if (model.Photo.Count > 0)
        //    {
        //        foreach (var itemPhoto in model.Photo)
        //        {
        //            //check if photo exist 
        //            var checkPhoto = await _photoRepository.GetPhotoById(itemPhoto.Id);

        //            //if photo does not exist insert


        //            photo.IsMain = itemPhoto.IsMain;
        //            photo.PublicId = itemPhoto.PublicId;
        //            photo.Url = itemPhoto.Url;
        //            photo.UserId = model.Id;

        //            photos.Add(photo);

        //        }

        //        await _photoRepository.InsertPhotos(photos);
        //    }

        //}

        public IEnumerable<PhotoDto> GetUserPhotos(int userId)
        {
            var photoDtos = new List<PhotoDto>();


            var photos = _photoRepository.GetUserPhotos(userId);
            foreach (var photo in photos)
            {
                var photoDto = new PhotoDto();

                photoDto.Id = photo.Id;
                photoDto.IsMain = photo.IsMain;
                photoDto.PublicId = photo.PublicId;
                photoDto.Url = photo.Url;
                photoDto.UserId = photo.UserId;

                photoDtos.Add(photoDto);
            }

            return photoDtos;
        }

        public async Task<Photos> GetMainPhotoByUserId(int id)
        {
            var photos = _photoRepository.GetUserPhotos(id);
            var getMainPhoto = photos.Where(r => r.IsMain == true).FirstOrDefault();
            return await Task.FromResult(getMainPhoto);

        }

        #endregion
    }
}
