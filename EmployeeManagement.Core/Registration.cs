using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Core
{
    public class Registration
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string Gender { get; set; }
    }
}
