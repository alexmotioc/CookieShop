﻿using CookieShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
        Task<Account> AddToFavorites(int accountid, Cookie cookie);
        Task<PurchaseHistory> BuyCart(int accountid, List<PurchaseItem> cookies);
        Task<PurchaseHistory> BuyCookie(int accountid, Cookie cookies, int amount);
        Task<List<Cookie>> GetFavorites(int id);
        Task<Account> RemoveFromFavorites(int accountid, Cookie cookie);
    }
}
