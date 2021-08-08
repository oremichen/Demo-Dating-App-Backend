using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.PhotoRepository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photos> GetUserPhotos(int userId);

        Task InsertPhotos(List<Photos> photos);

        Task<Photos> GetMainPhotoByUserId(int userId);
    }
}
