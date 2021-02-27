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
       public DateTime DateCreated { get; set; }
    }
}
