using CloudinaryDotNet.Actions;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.PhotoAppService
{
    public interface IPhotoService
    {
        Task<PhotoDto> AddPhotoAsync(IFormFile file, int id);
        Task<DeletionResult> AddPhotoAsync(string publicId);
        Task<List<Photos>> GetUserPhotos(int userId);
        Task UpdatePhoto(Photos photos);
        Task DeletePhotoById(int id);
    }
}
