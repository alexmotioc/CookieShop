using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly CookieShopDbContextFactory _contextFactory;
        private readonly GenericDataService<Account> _dataService;
        public AccountDataService(CookieShopDbContextFactory cookieShopDbContextFactory)
        {
            _contextFactory = cookieShopDbContextFactory;
            _dataService = new GenericDataService<Account>(_contextFactory); ;
        }

        public async Task<Account> Create(Account entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _dataService.Delete(id);

        }

        //private readonly NonQueryDataService<Account> _nonQueryDataService;

        //public AccountDataService(SimpleTraderDbContextFactory contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //    _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        //}

        //public async Task<Account> Create(Account entity)
        //{
        //    return await _nonQueryDataService.Create(entity);
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    return await _nonQueryDataService.Delete(id);
        //}

        public async Task<Account> Get(int id)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.PurchaseHistory)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.PurchaseHistory)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.PurchaseHistory)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.PurchaseHistory)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        public Task<Account> Update(int id, Account entity)
        {
            throw new NotImplementedException();
        }

        //public async Task<Account> Update(int id, Account entity)
        //{
        //    return await _nonQueryDataService.Update(id, entity);
        //}
        

        public async Task<List<Cookie>> GetFavorites(int id)
        {
           

            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
               var resp = await context
                    .Accounts
                    .Include((g) => g.FavoriteCookies)
                    .ThenInclude((b) => b.Cookie)
                    .Where((e) => e.Id == id)
                    .FirstOrDefaultAsync();

                return resp.FavoriteCookies.Select(a => a.Cookie).ToList();
              
            }
        }

        public async Task<Account> RemoveFromFavorites(int accountid, Cookie cookie)
        {
            var favoriteCookie = new FavoriteCookies() { CookieID = cookie.Id, AccountID = accountid };

            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {

                context.FavoriteCookies.Remove(favoriteCookie);
                context.SaveChanges();
                return await context.Accounts
                    .Include(a => a.FavoriteCookies)
                    .FirstOrDefaultAsync((e) => e.Id == accountid);
            }
        }

        public async Task<PurchaseHistory> BuyCookie(int accountid, Cookie cookie, int amount)
        {
            

            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                var account = await context.Accounts.FirstAsync((e) => e.Id == accountid);
                var cookiedb  = (await context.Cookies.FirstAsync((e) => e.Id == cookie.Id));
                var boughtCookie = new PurchaseHistory()
                {
                    Cookie = cookiedb,
                    Amount = amount,
                    AccountId = accountid,
                    DateProcessed = DateTime.Now,
                    IsPurchase = true
                };
               
                var result = await context.PurchaseHistory.AddAsync(boughtCookie);
                var stock = await context.Stocks.FirstOrDefaultAsync((e) => e.Cookie.Id == cookie.Id);
                stock.Amount--;

                account.Balance -= cookiedb.Price;

                context.SaveChanges();
                return result.Entity;
            }
            //throw new NotImplementedException();
        }

        public async Task<Account> AddToFavorites(int accountid, Cookie cookie)
        {
            var favoriteCookie = new FavoriteCookies() { CookieID = cookie.Id, AccountID = accountid };

            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {

                await context.FavoriteCookies.AddAsync(favoriteCookie);
                context.SaveChanges();
                return await context.Accounts
                    .Include(a => a.FavoriteCookies)
                    .FirstOrDefaultAsync((e) => e.Id == accountid);
            }
        }


    }
}
