using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.WPF.ViewModels.Factories
{
   public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
