

using System;

namespace EmployeeManagement.Core
{
    public class Roles
    {
        public int RoleId { get; set; }

        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
    public class UserRoles
    {
        public int RoleId { get; set; }

        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
