using CookieShop.Domain.Models;

namespace CookieShop.API.Controllers
{
    public class CookieResponse
    {
        public string Name { get; set; }
        public CookieType Type { get; set; }
        public int Price { get; set; }
        public int Sweeteners { get; set; }
        
        public double RatingAvg { get; set; }
    }
}