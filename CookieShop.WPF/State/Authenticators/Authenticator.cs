using CookieShop.Domain.Models;
using CookieShop.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {

        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User CurrentAccount { get; private set; }

        public bool isLoggedIn => CurrentAccount != null;

        Account IAuthenticator.CurrentAccount => throw new NotImplementedException();

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                Account account = await _authenticationService.Login(username, password);
               
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<Account> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmPassword);
        }

     }
}
