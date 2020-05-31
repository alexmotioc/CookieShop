using AutoMapper;
using CookieShop.API.Controllers;
using CookieShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookieShop.API.Controllers.AccountController;

namespace CookieShop.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Cookie, CookieResponse>();
            CreateMap<CookiePurchase, PurchaseItem>();
           
        }
    }
}
