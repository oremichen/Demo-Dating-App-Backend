using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class MessageParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";
    }
}
