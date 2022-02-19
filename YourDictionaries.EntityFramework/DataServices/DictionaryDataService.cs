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
                IEnumerable<Dictionary> dic = await context.Set<Dictionary>().Include(d => d.Phrases).ToListAsync();
                return dic;
            }
        }
    }
}
