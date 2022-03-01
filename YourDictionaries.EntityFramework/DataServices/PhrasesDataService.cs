using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace YourDictionaries.EntityFramework.DataServices
{
    public class PhrasesDataService : GenericDataService<Phrase>, IPhrasesDataService
    {
        public PhrasesDataService(AppDbContextFactory appDbContextFactory) : base(appDbContextFactory) { }

        public async Task AddPhraseToDictionary(Phrase phrase, int dictionaryId)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                var dic = await context.Dictionaries.SingleOrDefaultAsync(d => d.Id == dictionaryId);
                phrase.DictionaryId = dic.Id;
                await context.Phrases.AddAsync(phrase);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Phrase>> GetPhrasesFromDictionary(int dictionaryId)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                var phrases = context.Phrases.Include(p => p.Dictionary).Where(p => p.DictionaryId == dictionaryId);
                var list = await phrases.ToListAsync();
                return list;
            }
        }
    }
}
