using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly CookieShopDbContextFactory _contextFactory;
        public AccountDataService(CookieShopDbContextFactory cookieShopDbContextFactory)
        {
            _contextFactory = cookieShopDbContextFactory;
        }

        public async Task<Account> Create(Account entity)
        {
            using (CookieShopDbContext context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<Account>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
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

    }
}
