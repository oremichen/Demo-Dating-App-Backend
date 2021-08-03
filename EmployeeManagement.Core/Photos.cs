using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class Photos
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
