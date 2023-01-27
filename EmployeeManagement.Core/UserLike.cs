using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class UserLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LikedBy { get; set; }
    }
}
