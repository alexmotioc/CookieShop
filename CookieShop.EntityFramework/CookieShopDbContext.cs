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
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public DbSet<PurchaseItem> purchaseItems { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<CookieRating> CookieRatings { get; set; }
        public DbSet<FavoriteCookies> FavoriteCookies { get; set; }
        public DbSet<Stock> Stocks { get; set; }


        public CookieShopDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseItem>().HasOne(a => a.PurchaseHistory);
            modelBuilder.Entity<PurchaseItem>().HasOne(a => a.Cookie).WithMany(c => c.PurchaseHistory).HasForeignKey(c => c.CookieId);
            
            //modelBuilder.Entity<PurchaseHistory>().HasOne(a => a.Cookie);
            //Entity<AssetTransaction>.OwnsOne(a => a.Stock);
            // modelBuilder.Entity<AssetTransaction>.OwnsOne(a => a.Stock);
            modelBuilder.Entity<Stock>().HasOne(s => s.Cookie).WithOne(c => c.Stock).HasForeignKey<Cookie>(c=> c.StockID);


            modelBuilder.Entity<CookieRating>().HasKey(c => new { c.UserID, c.CookieID });
            modelBuilder.Entity<CookieRating>().HasOne(cr => cr.Cookie).WithMany(c => c.Ratings).HasForeignKey(cr => cr.CookieID);
            modelBuilder.Entity<CookieRating>().HasOne(cr => cr.User).WithMany(c => c.Ratings).HasForeignKey(cr => cr.UserID);
            modelBuilder.Entity<FavoriteCookies>().HasKey(c => new { c.AccountID, c.CookieID });
            modelBuilder.Entity<FavoriteCookies>().HasOne(fc => fc.Account).WithMany(c => c.FavoriteCookies).HasForeignKey(cr => cr.AccountID);
            modelBuilder.Entity<FavoriteCookies>().HasOne(fc => fc.Cookie).WithMany(c => c.AccountsIsFavouredBy).HasForeignKey(cr => cr.CookieID);


            base.OnModelCreating(modelBuilder);
        }

    }
}
