using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class FavoriteCookies
    {
            [Key]
            public int CookieID { get; set; }
            public Cookie Cookie { get; set; }

        [Key]
        public int AccountID { get; set; }
        public Account Account { get; set; }
    }
}
