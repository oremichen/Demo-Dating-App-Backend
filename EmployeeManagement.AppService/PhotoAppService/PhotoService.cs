using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.PhotoRepository;
using System;
using System.Collections.Generic;
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
            try
            {
                var photoDtos = new List<PhotoDto>();
                var photoDto = new PhotoDto();

                var photos =  _photoRepository.GetUserPhotos(userId);
                foreach (var photo in photos)
                {
                    photoDto.Id = photo.Id;
                    photo.IsMain = photo.IsMain;
                    photo.PhotoId = photo.PhotoId;
                    photo.PublicId = photo.PublicId;
                    photo.Url = photo.Url;

                    photoDtos.Add(photoDto);
                }

                return photoDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
