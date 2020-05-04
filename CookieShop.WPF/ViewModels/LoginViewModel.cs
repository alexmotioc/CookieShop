using CookieShop.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using CookieShop.WPF.Models;
using System.Windows.Input;
using CookieShop.WPF.Commands;

namespace CookieShop.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //private IAuthenticator authenticator;

        private string _username;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand LoginCommand { get; }
        
        public LoginViewModel(IAuthenticator authenticator)
        {
            LoginCommand = new LoginCommand(this, authenticator);
        }


    }
}
