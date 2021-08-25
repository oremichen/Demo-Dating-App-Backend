using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.PhotoAppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            try
            {
                var result = await _photoService.AddPhotoAsync(file, id);

                if (result == null)
                {
                    return BadRequest("Photo upload failed");
                }
                return Ok(StatusCodes.Status201Created);
            }

            catch (Exception ex)
            {
                return BadRequest($"Photo upload failed {ex}");
            }
           
        }

        [HttpPut]
        [Route("SetMainPhoto")]
        public async Task<ActionResult> SetMainPhoto(int id, int userId)
        {
            try
            {
                var photoList = await _photoService.GetUserPhotos(userId);
                var photo = photoList.Where(x => x.Id == id).FirstOrDefault();

                if (photo.IsMain == true)
                {
                    return BadRequest("This photo is already your main");
                }

                //set previous main to false
                var mainphoto = photoList.Where(x => x.IsMain == true).FirstOrDefault();
                mainphoto.IsMain = false;
                await _photoService.UpdatePhoto(mainphoto);

                //set new photo to main
                photo.IsMain = true;
                await _photoService.UpdatePhoto(photo);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to set main photo {ex}");
            }
           
        }
    }
}
