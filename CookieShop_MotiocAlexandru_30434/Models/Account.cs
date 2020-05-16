using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Account : DomainObject
    {
        public int Id { get; set; }

        public User AccountHolder { get; set; }
        public double Balance { get; set; }

        public IEnumerable<PurchaseHistory> PurchaseHistory { get; set; }
        public IEnumerable<Cookie> FavoriteCookies { get; set; }
        public IEnumerable<CookieRating> Ratings { get; set; }


    }
}
