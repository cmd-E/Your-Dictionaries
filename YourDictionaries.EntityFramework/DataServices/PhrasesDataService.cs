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

        public async Task UpdatePhrase(Phrase phrase)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                var phraseToEdit = await context.Phrases.FirstOrDefaultAsync(c => c.Id == phrase.Id);
                phraseToEdit.Expression = phrase.Expression;
                phraseToEdit.Meaning = phrase.Meaning;
                phrase.Transcription = phrase.Transcription;
                phrase.Translation = phrase.Translation;
                phraseToEdit.Dictionary = phrase.Dictionary;
                phrase.DictionaryId = phrase.DictionaryId;
                await context.SaveChangesAsync();
            }
        }
    }
}
