using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.AppService.RolesAppServices;
using EmployeeManagement.Core;
using EmployeeManagement.Repository.RoleRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IRolesAppService _rolesAppService;
        private readonly IRoleRepo _roleRepo;

        public RolesController(IRolesAppService rolesAppService, IRoleRepo roleRepo)
        {
            _rolesAppService = rolesAppService;
            _roleRepo = roleRepo;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IEnumerable<RolesDto>> GetAllRoles()
        {
            try
            {
                return await _rolesAppService.GetAllRoles();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //[HttpGet]
        //[Route("GetRoleById")]
        //public async Task<RolesDto> GetRoleById([FromQuery]int id)
        //{
        //    try
        //    {
        //        if(id <= 0)
        //        {
        //            throw new ArgumentException("Invalid query value");
        //        }

        //        return await _rolesAppService.GetRolesById(id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        [HttpPost]
        [Route("CreateNewRole")]
        public async Task<IActionResult> CreateNewRole([FromBody]CreateRolesDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model");
                }
                var doesExist = await _rolesAppService.CheckIfNameExist(model.RoleName);
                if (doesExist == true) { return BadRequest(new { message = "User name already exist in our database" }); }

                var result = await _rolesAppService.CreateNewUserRole(model);
                return Ok(result);
                
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }


        [HttpPut]
        [Route("UpdateRole")]
        public async Task<Roles> UpdateRole([FromBody]Roles model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model");
                }

                return await _rolesAppService.UpdateUserRole(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var result = await _rolesAppService.DeleteUserRole(id);
                if (result == true)
                {
                    return Ok(new { message = "Delete action was successful" });
                }
                return BadRequest(new { message = "Delete action was unsuccessful"});
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
