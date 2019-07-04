using Microsoft.EntityFrameworkCore;
using VegaStarter.Models;

namespace VegaStarter.Persistence
{
    public class VegaDbContext:DbContext
    {
        public VegaDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().ToTable("Makes");
          
        }
    }
}