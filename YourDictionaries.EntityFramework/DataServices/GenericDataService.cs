using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices.Interfaces;

namespace YourDictionaries.EntityFramework.DataServices
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly AppDbContextFactory _appDbContextFactory; // using factory instead of actual context because using context directly isn't thread save
        protected AppDbContextFactory AppDbContextFactory => _appDbContextFactory;
        public GenericDataService(AppDbContextFactory appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (AppDbContext context = _appDbContextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AppDbContext context = _appDbContextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (AppDbContext context = _appDbContextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (AppDbContext context = _appDbContextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities; 
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (AppDbContext context = _appDbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
