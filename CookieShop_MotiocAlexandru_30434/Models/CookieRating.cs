using System.ComponentModel.DataAnnotations;

namespace CookieShop.Domain.Models
{
    public class CookieRating : DomainObject
    {
        [Key]
        public int CookieID { get; set; }
        public virtual Cookie Cookie{ get; set;}

        [Key]
        public int UserID { get; set; }
        public virtual Account User { get; set; }
        public int Rating { get; set; }
    }
}