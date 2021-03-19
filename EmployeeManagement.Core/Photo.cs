using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

    }
}
