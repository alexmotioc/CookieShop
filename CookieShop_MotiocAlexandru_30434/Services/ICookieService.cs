using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.EntityFramework.Services
{
    public interface ICookieService : IDataService<Cookie>
    {
        public  Task<IEnumerable<Cookie>> GetAll(string name, string type, string price, string sweeteners);
    }
}
