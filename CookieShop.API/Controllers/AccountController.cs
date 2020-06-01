using AutoMapper;
using CookieShop.API.Services;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]



   
    public class AccountController : ControllerBase
    {
            private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;



        public AccountController(IAccountService accountService, ITokenService tokenService,IMapper mapper)
            {   
                _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;


    }
    [Authorize]
        [HttpPost("add-favorite")]
        public async Task<Account> AddFavorite([FromBody] Cookie cookieBody)
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));
            var account = await _accountService.AddToFavorites(userId, cookieBody);
            return account;

        }

        [Authorize]
        [HttpGet("favorites")]
        public async Task<List<Cookie>> Favorites()
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));
            var favorites = await _accountService.GetFavorites(userId);
            return favorites;

        }

        [Authorize]
        [HttpGet("info")]
        public async Task<UserInfoResponse> Info()
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));
            var user = await _accountService.Get(userId);
            return new UserInfoResponse
            {
                Balance = user.Balance,
                User = user.AccountHolder.Username
            };

        }

        [Authorize]
        [HttpPost("remove-favorite")]
        public async Task<Account> RemoveFromFavorites([FromBody] Cookie cookieBody)
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));
            var account = await _accountService.RemoveFromFavorites(userId, cookieBody);
            return account;

        }

        [Authorize]
        [HttpPost("buy-cart")]
        public async Task<PurchaseHistory> BuyCart([FromBody] List<CookiePurchase> purchaseCookieBody)
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));

            var model = _mapper.Map<List<PurchaseItem>>(purchaseCookieBody);
            var list = new List<PurchaseItem>();
            foreach(var item in purchaseCookieBody)
            {
                list.Add(new PurchaseItem
                {
                    Amount = item.Amount,
                    //Cookie = item.Cookie,
                    CookieId = item.Cookie.Id
                });
            }

            var purcase = await _accountService.BuyCart(userId, list);
            return purcase;

        }

        public class CookiePurchase
        {
            public Cookie Cookie { get; set; }
            public int Amount { get; set; }

        }


        [Authorize]
        [HttpPost("buy-cookie")]
        public async Task<PurchaseHistory> Buy([FromBody] Cookie purchaseCookieBody)
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));

            var purcase = await _accountService.BuyCookie(userId, purchaseCookieBody, 1);
            return purcase;

        }
        public class UserInfoResponse
        {
            public double Balance { get;  set; }
            public string User { get;  set; }
        }
    }
}
 