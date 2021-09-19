using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.Helpers;
using EmployeeManagement.AppService.PasswordHelper;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.AppService.UsersAppServices;
using EmployeeManagement.Repository.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserAppService _userAppService;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public UsersController(ILogger<UsersController> logger, IUserAppService userAppService, IUserRepo userRepo, IMapper mapper, ITokenServices tokenServices)
        {
            _logger = logger;
            _tokenServices = tokenServices;
            _userAppService = userAppService;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateNewUser")]
        [Produces(typeof(Response))]
        public async Task<IActionResult> CreateNewUser([FromBody]CreateUsersDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model");
                }
                var doesExist = await _userAppService.CheckIfNameExist(model.Email);
                if (doesExist == true) { return BadRequest(new { message = "Email already exist in our database" }); }

                var result = await _userAppService.CreateUsers(model);
                if (result != null) { return Ok(new Response {userDto = result, Message = $"User with email {model.Email} was created successfully" }); }

                return BadRequest(new Response { userDto= null, Message = "User creation failed" });
            }
            catch (Exception e)
            {
                _logger.LogError("something went wrong", e);
                return BadRequest(new Response { userDto = null, Message = "User creation failed" });
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateMembersDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = User.FindFirst(ClaimTypes.Name)?.Value;
                    var userAuth = User.FindFirst(ClaimTypes.AuthenticationMethod)?.Value;

                    var updateUser = await _userAppService.UpdateUser(model);
                    if (updateUser != null)
                    {
                        return Ok("Update successful");
                    }
                    return BadRequest("Update request failed");
                }
                return BadRequest("Model is invalid");
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllUsers")]
        [Produces(typeof(PagedList<Members>))]
        public async Task<IActionResult> GetAllUsers([FromQuery]UserParams userParams)
        {
            try
            {
                var result = await _userAppService.GetAllUsers(userParams);
                Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("something went wrong", e);
                throw e;
            }
        }


        [HttpGet]
        [Authorize]
        [Route("GetUserById")]
        [Produces(typeof(Members))]
        public async Task<IActionResult> GetUserById([FromQuery]int id)
        {
            try
            {
                var result = await _userAppService.GetUsersById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("something went wrong", e);
                throw e;
            }
        }

        #region Login method
        [HttpPost]
        [Route("Login")]
        [Produces(typeof(UserDto))]
        public async Task<IActionResult> Login([FromBody]LoginUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Invalid model" });
                }

                var result = await _userRepo.GetAllUsers();
                var user = result.AsQueryable().Where(x => x.Email == model.Email).SingleOrDefault();
                if (user == null) { return Unauthorized("You are not authorised, please register"); }

                //get the new hashed password of the user by the using the password salt in the db
                //create a new hash from the computed password
                //compare both hashes if they match
                var passwd = EncryptPassword.GenerateSHAHash(model.Password, user.PasswordSalt);

                if (user.PasswordHash == passwd)
                {
                    
                    var response = _mapper.Map<CreateUsersDto>(user);
                    response.Password = model.Password;

                    //generate token
                    var token = await _tokenServices.CreateToken(response);

                    var usr =  new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Token = token,
                        Url = _userAppService.GetPhotoUrl(user.Id)
                    };
                    return Ok(usr);
                }

                return BadRequest("Login failed, password is not correct");

            }
            catch (Exception e)
            {
                _logger.LogError("Login failed", e);
                return BadRequest("Login failed");
            }
            #endregion
        }
    }
}
