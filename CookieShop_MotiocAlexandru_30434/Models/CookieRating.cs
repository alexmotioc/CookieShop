using System.ComponentModel.DataAnnotations;

namespace CookieShop.Domain.Models
{
    public class CookieRating : DomainObject
    {
        [Key]
        public int CookieID { get; set; }
        public Cookie Cookie{ get; set;}

        [Key]
        public int UserID { get; set; }
        public Account User { get; set; }
        public int Rating { get; set; }
    }
}