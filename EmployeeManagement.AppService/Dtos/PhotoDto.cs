using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int PublicId { get; set; }
        public int UserId { get; set; }
    }

    public class CreatePhoto
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int PublicId { get; set; }
        public int UserId { get; set; }
    }

    public class UpdatePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int PublicId { get; set; }
        public int UserId { get; set; }
    }
}
