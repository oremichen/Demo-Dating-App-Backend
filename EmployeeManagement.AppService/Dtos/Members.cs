using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime LastAcvtive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string PhotoUrl { get; set; }

        public int Age { get; set; }

        public List<PhotoDto> Photo { get; set; }
        
    }

    public class Response
    {
        public UserDto userDto { get; set; }
        public string Message { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
