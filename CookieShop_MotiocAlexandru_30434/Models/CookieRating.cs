using System.ComponentModel.DataAnnotations;

namespace CookieShop.Domain.Models
{
    public class CookieRating : DomainObject
    {
        [Key]
        public int CookieID { get; set; }
        public Cookie Cookie{ get; set;}
        public Account User { get; set; }
        public int Rating { get; set; }
    }
}