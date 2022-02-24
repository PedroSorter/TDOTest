using Data.EntityConfigurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbOptions) : base(dbOptions) { }
        public DbSet<ImageEntity> ImageList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImageEntity>(new ImageEntityConfiguration().Configure);
        }
    }
}
