using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ServicelifetimeTest
{
    public class MyChildService
    {
        public static int CreationCount { get; private set; }

        public MyChildService()
        {
            CreationCount++;
        }
    }
}
