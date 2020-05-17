using System;
using System.Collections.Generic;
using System.Text;
using CookieShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookieShop.EntityFramework
{
    public class CookieShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PurchaseHistory> AssetTransactions { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<CookieRating> CookieRatings { get; set; }
        public DbSet<FavoriteCookies> FavoriteCookies { get; set; }

        public CookieShopDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseHistory>().OwnsOne(a => a.Stock);
                //Entity<AssetTransaction>.OwnsOne(a => a.Stock);
                // modelBuilder.Entity<AssetTransaction>.OwnsOne(a => a.Stock);
            base.OnModelCreating(modelBuilder);
        }

    }
}
