using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.AppService.PhotoAppService
{
    public interface IPhotoService
    {
        IEnumerable<PhotoDto> GetUserPhotos(int userId);
        Task InsertUserPhotos(MembersDto model);
        Task<Photos> GetMainPhotoByUserId(int id);
    }
}
