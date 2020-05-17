using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]



   
    public class AccountController : ControllerBase
    {
            private readonly IAccountService _accountService;


            public AccountController(IAccountService accountService)
            {   
                _accountService = accountService;
               
            }
        [HttpPost("add-favorite")]
        public async Task<Account> AddFavorite([FromBody] Cookie cookieBody)
        {
            var Account = await _accountService.AddToFavorites(1, cookieBody);
            return Account;

        }

    }
}
