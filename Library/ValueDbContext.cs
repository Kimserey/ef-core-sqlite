using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class ValueDbContext: DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NoteCategory> Links { get; set; }

        public ValueDbContext(DbContextOptions<ValueDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>()
                .Property<string>("TagCollection")
                .HasField("_tags");

            modelBuilder.Entity<NoteCategory>()
                .HasKey(x => new { x.NoteId, x.CategoryId });
        }
    }
}
