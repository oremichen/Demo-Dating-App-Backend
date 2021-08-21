using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.PhotoAppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    public class PhotosController : BaseController
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        [Route("UploadphotosAsync")]
        public async Task<ActionResult<PhotoDto>> UploadphotosAsync(IFormFile file, int id)
        {
            var result = await _photoService.AddPhotoAsync(file, id);

            if (result == null)
            {
                return BadRequest("Photo upload failed");
            }
            return Ok(StatusCodes.Status201Created);
        }
    }
}
