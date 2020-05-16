namespace CookieShop.Domain.Models
{
    public class CookieRating : DomainObject
    {
        public Cookie Cookie{ get; set;}
        public User User { get; set; }
        public int Rating { get; set; }
    }
}