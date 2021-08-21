using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class MembersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public string KnownAs { get; set; }
        public DateTime LastAcvtive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<CreatePhoto> Photo { get; set; }

    }

    public class UpdateMembersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public string KnownAs { get; set; }
        public DateTime LastAcvtive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
