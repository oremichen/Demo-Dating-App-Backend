using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.AppService.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.ControllerBase
{
    [ServiceFilter(typeof(LogUser))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        
    }
}
