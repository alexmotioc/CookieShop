using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class PurchaseHistory : DomainObject
    {
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public bool IsPurchase { get; set; } //? 

        public virtual IList<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();

        public DateTime DateProcessed { get; set; }
    }
}
