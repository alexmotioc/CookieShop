using CookieShop.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase 
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

    }
}
