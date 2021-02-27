using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ApiResponseHelper
{
    public class ApiResponseBase
    {
        public string Message { get; set; }
        public Object Obj { get; set; } 
    }

    public class ResponseObject<T>
    {
        public T Object
        {
            get;
            set;
        }
    }
}
