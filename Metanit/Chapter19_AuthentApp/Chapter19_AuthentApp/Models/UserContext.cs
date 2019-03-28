using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter19_AuthentApp.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
            Database.EnsureCreatedAsync();
        }
    }
}
