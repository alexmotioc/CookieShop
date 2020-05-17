using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.Domain.Models
{
    public class User : DomainObject
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime DateJoined { get; set; }

        public string PasswordHash { get; set; }
    }
}
