using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class CreateRolesDto
    {
        [Required]
        public string RoleName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginUser
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
