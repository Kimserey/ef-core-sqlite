﻿using Microsoft.EntityFrameworkCore;

namespace Library
{

    public class ValueDbContext: DbContext
    {
        public DbSet<Value> Values { get; set; }

        public ValueDbContext()
        {

        }

        public ValueDbContext(DbContextOptions<ValueDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>()
                .Property("_tags");
        }
    }
}