using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.DTOs;

namespace YourDictionaries.DbContexts
{
    public class YourDictionariesDbContext : DbContext
    {
        public DbSet<PhraseDTO> Phrases { get; set; }
        public DbSet<DictionaryDTO> Dictionaries { get; set; }
        public YourDictionariesDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhraseDTO>()
                .HasOne(p => p.AssignedDictionary)
                .WithMany(d => d.Phrases);
            modelBuilder.Entity<DictionaryDTO>()
                .HasMany(d => d.Phrases)
                .WithOne(p => p.AssignedDictionary)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
