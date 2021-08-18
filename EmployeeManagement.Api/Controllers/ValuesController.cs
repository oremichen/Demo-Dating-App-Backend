using EmployeeManagement.Api.ControllerBase;
using EmployeeManagement.Api.ServicelifetimeTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    public class ValuesController : BaseController
    {
        private readonly MyFatherService _myFatherService;
        private readonly MyMotherService _myMotherService;

        public ValuesController(MyFatherService myFatherService, MyMotherService myMotherService)
        {
            _myFatherService = myFatherService;
            _myMotherService = myMotherService;
        }

        [HttpGet]
        public string Get()
        {
            return $"Father Creation Count : {MyFatherService.CreationCount}. Mother Creation Count : " +
                $"{MyFatherService.CreationCount}. Child Creation Count : {MyChildService.CreationCount}";
        }
    }
}
