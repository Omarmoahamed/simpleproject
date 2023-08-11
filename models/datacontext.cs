using Microsoft.EntityFrameworkCore;

namespace simpleproject.models
{
    public class datacontext:DbContext
    {
        public datacontext(DbContextOptions<datacontext> opts):base(opts) { }

        public DbSet<product> products => Set<product>();

        public DbSet<Category> categories => Set<Category>();

        public DbSet<supplier> suppliers => Set<supplier>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new reviewmap(modelBuilder.Entity<review>());

            modelBuilder.Entity<product>().Property(c => c.quality).HasConversion<int>();
            
        }
    }
}
