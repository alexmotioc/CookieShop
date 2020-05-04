using CookieShop.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CookieShop.WPF.State.Navigators
{

    public enum ViewType
    {
        Login,
        Home,
        Portofolio
    }

    public interface INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }
    }
}
