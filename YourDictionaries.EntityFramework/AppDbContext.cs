using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.EntityFramework
{
    public class AppDbContext : DbContext
    {


        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phrase>().HasOne(p => p.AssignedDictionary);
            modelBuilder.Entity<Dictionary>().HasMany(d => d.Phrases);
            base.OnModelCreating(modelBuilder);
        }
    }
}
