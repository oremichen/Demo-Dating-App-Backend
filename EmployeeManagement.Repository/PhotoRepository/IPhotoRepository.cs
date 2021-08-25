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

        Task InsertPhotos(Photos photos);

        Task<Photos> GetPhotoById(int id);

        Task UpdatePhoto(Photos photos);
    }
}
