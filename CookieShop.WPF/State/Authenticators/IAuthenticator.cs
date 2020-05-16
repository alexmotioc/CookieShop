using CookieShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool isLoggedIn { get; }

        Task<Account> Register(string email, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);

        void Logout();

    }
}
