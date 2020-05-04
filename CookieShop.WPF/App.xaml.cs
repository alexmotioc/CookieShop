using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using CookieShop.Domain.Services.AuthenticationServices;
using CookieShop.EntityFramework;
using CookieShop.EntityFramework.Services;
using CookieShop.WPF.State.Authenticators;
using CookieShop.WPF.State.Navigators;
using CookieShop.WPF.ViewModels;
using CookieShop.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CookieShop.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
            //var test = authentication.Login("testuser", "test123");
         
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            //window.DataContext = new MainViewModel();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddSingleton<CookieShopDbContextFactory>();
            services.AddSingleton(typeof(IDataService<>), typeof(GenericDataService<>));
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();


            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();
            //services.AddScoped<BuyViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            return services.BuildServiceProvider();
        }
    }
}
