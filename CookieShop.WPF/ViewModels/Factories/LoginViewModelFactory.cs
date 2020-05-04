using CookieShop.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.WPF.ViewModels.Factories
{
     public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;

        public LoginViewModelFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator);
        }
    }
}
