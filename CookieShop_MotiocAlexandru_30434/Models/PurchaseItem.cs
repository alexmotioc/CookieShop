using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class PurchaseItem : DomainObject
    {
        public virtual int CookieId { get; set; }
        public virtual Cookie Cookie { get; set; }

        public int Amount { get; set; }

        public virtual PurchaseHistory PurchaseHistory { get; set; }
    }
}
