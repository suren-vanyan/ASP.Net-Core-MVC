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
    }
}
