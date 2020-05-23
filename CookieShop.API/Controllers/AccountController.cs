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


        public AccountController(IAccountService accountService, ITokenService tokenService)
            {   
                _accountService = accountService;
            _tokenService = tokenService;
               
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
        [HttpPost("buy-cookie")]
        public async Task<PurchaseHistory> Buy([FromBody] Cookie purchaseCookieBody)
        {
            var token = Request.Headers["Authorization"][0]
           .Substring("Bearer ".Length);
            var userId = int.Parse(_tokenService.GetClaim(token, "nameid"));
           
                var purcase = await _accountService.BuyCookie(userId, purchaseCookieBody,1);
            return purcase;

        }

    }
}
