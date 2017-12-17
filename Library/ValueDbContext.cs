using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class ValueDbContext: DbContext
    {
        public DbSet<Value> Values { get; set; }

        public ValueDbContext(DbContextOptions<ValueDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>()
                .Property<string>("TagCollection")
                .HasField("_tags");
        }
    }
}
