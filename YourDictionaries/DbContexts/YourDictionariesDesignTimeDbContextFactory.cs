using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourDictionaries.DbContexts
{
    public class YourDictionariesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<YourDictionariesDbContext>
    {
        public YourDictionariesDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=yourdic.db").Options;
            return new YourDictionariesDbContext(options);
        }
    }
}
