using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        public readonly CookieShopDbContextFactory _contextFactory;

        public GenericDataService(CookieShopDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity) //async used for not interfering with the UI
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
               
        }

        public async Task<bool> Delete(int id)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }

        }

        public async Task<T> Get(int id)
        {
            using(CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
              
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            
                return entities;
            }
                
        }

        public async Task<T> Update(int id, T entity)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;


            }
        }
    }
}
