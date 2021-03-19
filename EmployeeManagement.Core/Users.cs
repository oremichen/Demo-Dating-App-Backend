using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime LastAcvtive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
