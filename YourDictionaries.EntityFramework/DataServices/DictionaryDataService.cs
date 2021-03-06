using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YourDictionaries.EntityFramework.DataServices.Interfaces;

namespace YourDictionaries.EntityFramework.DataServices
{
    public class DictionaryDataService : GenericDataService<Dictionary>, IDictionaryDataService
    {
        public DictionaryDataService(AppDbContextFactory appDbContextFactory) : base(appDbContextFactory) { }

        public async Task<IEnumerable<Dictionary>> GetDictionaries()
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                IEnumerable<Dictionary> dic = await context.Dictionaries.Include(d => d.Phrases).ToListAsync();
                return dic;
            }
        }

        public async Task<IEnumerable<Dictionary>> GetDictionariesForUser(int userId)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                IEnumerable<Dictionary> dics = await context.Dictionaries.Include(d => d.Phrases).Where(d => d.UserId == userId).ToListAsync();
                return dics;
            }
        }
    }
}
