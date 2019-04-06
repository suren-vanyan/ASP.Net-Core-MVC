﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
      
        public AppIdentityDbContext(DbContextOptions options):base(options)
        {
           
        }
    }
}
