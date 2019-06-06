using ExistingDb.Models.Logic;
using Microsoft.EntityFrameworkCore;

namespace ExistingDb.Models.Manual
{
    public class ManualContext : DbContext
    {
        public ManualContext(DbContextOptions<ManualContext> options)
                                                      : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Style> ShoeStyles { get; set; }

        public DbSet<ShoeWidth> ShoeWidths { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeWidth>().ToTable("Fittings");
            modelBuilder.Entity<ShoeWidth>().HasKey(t => t.Uniqueident);
            modelBuilder.Entity<ShoeWidth>().Property(t => t.Uniqueident).HasColumnName("id");
            modelBuilder.Entity<ShoeWidth>().Property(t => t.WidthName).HasColumnName("Name");

            base.OnModelCreating(modelBuilder);
        }
    }
}
