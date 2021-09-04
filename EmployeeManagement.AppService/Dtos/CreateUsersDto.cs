using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class CreateUsersDto
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "This field is required")]
        public string KnownAs { get; set; }

        public DateTime LastAcvtive { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "This field is required")]
        public string Gender { get; set; }
     
        [Required (ErrorMessage ="This field is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime DateOfBirth { get; set; }

    }
}
