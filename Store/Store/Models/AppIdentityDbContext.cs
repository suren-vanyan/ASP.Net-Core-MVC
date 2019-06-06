using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class AppIdentityDbContext:IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
