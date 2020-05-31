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

        public async Task<IEnumerable<Cookie>> GetAll(string name, CookieType? type, int? price, int? sweeteners, int? rating)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Cookie> entities = (await context.Set<Cookie>()
                    .Include((a) => a.Ratings)
                    .Include(c=> c.Stock)
                    .Where(cookie => 
                    (name == null ||name == string.Empty || cookie.Name.Contains(name)) 
                    && (type == null || cookie.Type == type) 
                    && (price == null || cookie.Price == price) 
                    && (sweeteners == null || cookie.Sweeteners == sweeteners)
                    
                    )
                    .ToListAsync())
                    .Where(cookie => (rating == null || Math.Round(cookie.RatingAvg) == rating))
                    .ToList()
                    ;

                return entities;
            }
        }
        public async Task<CookieRating> AddRatings(int userId, int cookieId, int rating)
        {
            var cookieRating = new CookieRating() { CookieID = cookieId, UserID = userId, Rating = rating};

            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {

                var newRating = await context.CookieRatings.AddAsync(cookieRating);
                context.SaveChanges();
                return newRating.Entity;
            }
        }
        public async Task<Cookie> Update(int id, Cookie entity)
        {
            return await _dataService.Update(id, entity);
        }

        public async Task<Cookie> UpdateStock(int cookieId, int amount)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                var stock = await context.Stocks.FirstOrDefaultAsync(s => s.Cookie.Id == cookieId);
                stock.Amount = amount;
                context.SaveChanges();
                return await context.Cookies
                    .Include(c => c.Stock)
                    .Include(c => c.AccountsIsFavouredBy)
                    .FirstOrDefaultAsync(s => s.Id == cookieId);
            }
        }
    }
}
