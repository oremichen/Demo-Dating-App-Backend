using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.PhotoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.PhotoAppService
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public IEnumerable<PhotoDto> GetUserPhotos(int userId)
        {
                var photoDtos = new List<PhotoDto>();
               

                var photos =  _photoRepository.GetUserPhotos(userId);
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
    }
}
