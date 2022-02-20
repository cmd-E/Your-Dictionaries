using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.EntityFramework.DataServices.Interfaces
{
    public interface IPhrasesDataService : IDataService<Phrase>
    {
        public Task AddPhraseToDictionary(Phrase phrase, int dictionaryId);
        public Task UpdatePhrase(Phrase phrase);
    }
}
