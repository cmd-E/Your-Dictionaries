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
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
