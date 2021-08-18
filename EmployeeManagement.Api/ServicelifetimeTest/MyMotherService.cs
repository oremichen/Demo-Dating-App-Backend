using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ServicelifetimeTest
{
    public class MyMotherService
    {
        private readonly MyChildService _childService;
        public static int CreationCount { get; private set; }

        
        public MyMotherService(MyChildService myChildService)
        {
            _childService = myChildService;
            CreationCount++;
        }
    }

    public class MyFatherService
    {
        private readonly MyChildService _childService;
        public static int CreationCount { get; private set; }

        public MyFatherService(MyChildService myChildService)
        {
            _childService = myChildService;
            CreationCount++;
        }
    }
}
