using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace CookieShop.Domain.Models
{
    public class Cookie :DomainObject
    {
        public string Name { get; set; }
        public CookieType Type { get; set; }
        public int Price { get; set; }
        public int Sweeteners { get; set; }
        public IList<CookieRating> Ratings { get; set; }
        public double RatingAvg => Ratings != null ? Ratings.Average(r => r.Rating) : 0;


    }

    //[JsonConverter(typeof(StringEnumConverter))]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CookieType
        {
        Chocolate,
        Vanilla,
        Fruit,

    }
}
