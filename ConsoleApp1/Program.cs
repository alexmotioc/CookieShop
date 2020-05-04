using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using CookieShop.EntityFramework;
using CookieShop.EntityFramework.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new CookieShopDbContextFactory());
            
           
            //Console.WriteLine(userService.GetAll().Result.Count());
            Console.WriteLine(userService.Update(1, new User() { Username = "TestUser" }).Result);


            Console.ReadLine();
        }
    }
}
