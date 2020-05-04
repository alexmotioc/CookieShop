using CookieShop.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookieShop.WPF.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _loginViewModelFactory;
        //private readonly BuyViewModel _buyViewModel;

        public RootViewModelFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
                    IViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                //case ViewType.Portofolio:
                //    return _portfolioViewModelFactory.CreateViewModel();
                //case ViewType.Buy:
                //    return _buyViewModel;
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
