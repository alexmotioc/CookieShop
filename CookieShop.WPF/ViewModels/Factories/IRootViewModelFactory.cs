using CookieShop.WPF.State.Navigators;

namespace CookieShop.WPF.ViewModels.Factories
{
    public interface IRootViewModelFactory {
        public ViewModelBase CreateViewModel(ViewType viewType);
    }
}
