using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace CookieShop.EntityFramework
{
    public class CookieShopDbContextFactory : IDesignTimeDbContextFactory<CookieShopDbContext>
    {
        public CookieShopDbContext CreateDbContext(string[] args = null)
        {
            //throw new NotImplementedException();
            var options = new DbContextOptionsBuilder<CookieShopDbContext>();
            options.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=CookieShopDB;Trusted_Connection=True;")
                .UseLazyLoadingProxies();
            return new CookieShopDbContext(options.Options);
        }
    }
}
