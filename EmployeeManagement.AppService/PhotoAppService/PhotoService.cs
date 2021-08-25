using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.Helpers;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.PhotoRepository;
using EmployeeManagement.Repository.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.PhotoAppService
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly Cloudinary _cloudinary;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;


        public PhotoService(IPhotoRepository photoRepository, IOptions<CloudinarySettings> config, IUserRepo userRepo, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _userRepo = userRepo;
            _mapper = mapper;

            var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(acc);
        }


        public async Task<PhotoDto> AddPhotoAsync(IFormFile file, int id)
        {
            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

           
            if (uploadResult.Error != null)
            {
                return null;
            }

            var user = await _userRepo.GetUsersById(id);

            var photo = new Photos
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId, 
                UserId = id
            };

            var photos = _photoRepository.GetUserPhotos(id);

            if (photos.Count() == 0)
            {
                photo.IsMain = true;
            }

            await _photoRepository.InsertPhotos(photo);
            var photoDto = _mapper.Map<PhotoDto>(photo);
            return photoDto;
            
        }

        public async Task<DeletionResult> AddPhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        public async Task<bool> CheckMainPhoto(int id)
        {
            var res = await _photoRepository.GetPhotoById(id);
            if (res.IsMain == true)
            {
                return true;
            }
            return false;
            
        }

        public async Task DeletePhotoById(int id)
        {
            await _photoRepository.DeletePhoto(id);
            await Task.CompletedTask;
        }

        public async Task<List<Photos>> GetUserPhotos(int userId)
        {
            var photoList = _photoRepository.GetUserPhotos(userId);
            return await Task.FromResult(photoList.ToList());
        }

        public async Task UpdatePhoto(Photos photos)
        {
             await _photoRepository.UpdatePhoto(photos);
             await Task.CompletedTask;
        }
    }
}
