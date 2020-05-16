using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Cookie :DomainObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string Sweeteners { get; set; }
    }
}
