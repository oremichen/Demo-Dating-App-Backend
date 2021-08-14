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

       

      
    }
}
