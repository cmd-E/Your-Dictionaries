using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourDictionaries.EntityFramework
{

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Whenever migrations are run, this method will be executed to get options
        /// </summary>
        public AppDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=YD_DB;Trusted_Connection=True;");
            return new AppDbContext(dbContextBuilder.Options);
        }
    }
}
