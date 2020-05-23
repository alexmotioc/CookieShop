using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace CookieShop.Domain.Models
{
    public class Cookie : DomainObject
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CookieType Type { get; set; }
        public int Price { get; set; }
        public int Sweeteners { get; set; }
        public virtual  IList<CookieRating> Ratings { get; set; } = new List<CookieRating>();
        public double RatingAvg => Ratings.Count != 0 ? Ratings.Average(r => r.Rating) : 0;

        public virtual IList<FavoriteCookies> AccountsIsFavouredBy {get; set; } = new List<FavoriteCookies>();
        public int StockID { get; set; }
        public virtual  Stock Stock { get; set; }
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CookieType
        {
        //[Display(Name = "It's summer")]
        Chocolate,
        Vanilla,
        Fruit,
    }
}
