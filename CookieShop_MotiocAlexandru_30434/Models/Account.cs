using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Account : DomainObject
    {
        public virtual User AccountHolder { get; set; }
        public double Balance { get; set; }

        public virtual IList<PurchaseHistory> PurchaseHistory { get; set; }
        public virtual IList<FavoriteCookies> FavoriteCookies { get; set; }
        public virtual IList<CookieRating> Ratings { get; set; }
    }
}
