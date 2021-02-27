using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.RegistrationAppService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    public class RegisteredUsersController : BaseController
    {
        private readonly IRegistrationAppServices _registrationAppServices;

        public RegisteredUsersController(IRegistrationAppServices registrationAppServices)
        {
            _registrationAppServices = registrationAppServices;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _registrationAppServices.GetRegisteredAllUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetUsresByEmail")]
        public async Task<IActionResult> GetUsresByEmail([FromQuery]string email)
        {
            try
            {
                var result = await _registrationAppServices.GetRegisteredUserByEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]RegistrationDto model)
        {
            try
            {
                var result = await _registrationAppServices.CreateUserRegistration(model);
                if (result != 0)
                {
                    return Ok(new { message = "User created successfully"});
                }
                return BadRequest(new {message = "User creation failed, please try again" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
