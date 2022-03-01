using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.EntityFramework.DataServices.Interfaces
{
    public interface IDictionaryDataService : IDataService<Dictionary>
    {
        Task<IEnumerable<Dictionary>> GetDictionaries();
        Task<IEnumerable<Dictionary>> GetDictionariesForUser(int userId);
    }
}
