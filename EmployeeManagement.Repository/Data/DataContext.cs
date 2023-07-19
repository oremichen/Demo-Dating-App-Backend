using EmployeeManagement.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Message> Messsage { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<UserLike> UserLike { get; set; }
    }
}
