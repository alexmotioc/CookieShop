using CookieShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string email, string username, string password, string confirmPassword);
        

        Task<Account> Login(string username, string password);
    }
}
