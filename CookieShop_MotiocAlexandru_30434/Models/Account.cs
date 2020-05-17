using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public double Balance { get; set; }

        public IList<PurchaseHistory> PurchaseHistory { get; set; }
        public IList<FavoriteCookies> FavoriteCookies { get; set; }
        public IList<CookieRating> Ratings { get; set; }
    }
}
