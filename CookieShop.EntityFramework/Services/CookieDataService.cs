using CookieShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.EntityFramework.Services
{
    public class CookieDataService : ICookieService
    {
        private readonly CookieShopDbContextFactory _contextFactory;
        private readonly GenericDataService<Cookie> _dataService;
        
        public CookieDataService(CookieShopDbContextFactory cookieShopDbContextFactory)
        {
         _contextFactory = cookieShopDbContextFactory;
            _dataService = new GenericDataService<Cookie>(_contextFactory); ;
        }
        public async Task<Cookie> Create(Cookie entity)
        {
            return await _dataService.Create(entity);
           
        }

        public async Task<bool> Delete(int id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<Cookie> Get(int id)
        {
            return await _dataService.Get(id);

        }

        public async Task<IEnumerable<Cookie>> GetAll()
        {
            return await _dataService.GetAll();

        }

        public async Task<IEnumerable<Cookie>> GetAll(string name, CookieType? type, int? price, int? sweeteners)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Cookie> entities = await context.Set<Cookie>()
                    .Where(cookie => (name == null || cookie.Name == name) && (type == null || cookie.Type == type) && (price == null || cookie.Price == price) && (sweeteners == null || cookie.Sweeteners == sweeteners))
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Cookie> Update(int id, Cookie entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
