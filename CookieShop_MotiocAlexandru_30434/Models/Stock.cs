using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Stock : DomainObject
    {
        public Cookie Cookie { get; set; }
        public int Amount { get; set; }
    }
}
