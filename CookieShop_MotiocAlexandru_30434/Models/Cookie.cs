using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class Cookie :DomainObject
    {
        public string Name { get; set; }
        public cookieType Type { get; set; }
        public int Price { get; set; }
        public int Sweeteners { get; set; }
        public IList<CookieRating> Ratings { get; set; }
        public double RatingAvg => Ratings != null ? Ratings.Average(r => r.Rating) : 0;


    }

    public enum cookieType
        {
        Chocolate,
        Vanilla,
        Fruit,

    }
}
