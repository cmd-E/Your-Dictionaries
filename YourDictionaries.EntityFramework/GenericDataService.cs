using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Services;

namespace YourDictionaries.EntityFramework
{
    public class GenericDataService<T> : IDataService<T>
    {
        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
