using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class PurchaseHistory : DomainObject
    {
        public Account Account { get; set; }

        public bool IsPurchase { get; set; }

        public Cookie Cookie { get; set; }

        public int Amount { get; set; }

        public DateTime DateProcessed { get; set; }
    }
}
