using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.Helpers
{
    public static class GetPhotosHelper
    {
        public static List<PhotoDto> GetPhotos(this List<Photos> photos)
        {
            var photoDtos = new List<PhotoDto>();

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
    }
}
