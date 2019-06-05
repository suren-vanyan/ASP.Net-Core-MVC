using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionApp.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
