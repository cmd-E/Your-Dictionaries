using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YourDictionaries.EntityFramework.DataServices.Interfaces
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
