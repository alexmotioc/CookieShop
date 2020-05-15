using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using CookieShop.Domain.Services.AuthenticationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(ILogger<AccountController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<Account> Login([FromBody] LoginBody loginBody)
        {
            return await _authenticationService.Login(loginBody.Email, loginBody.Password);
        }

        public class LoginBody
        {
             public string Email { get; set; }
             public string Password { get; set; }
        }

        [HttpPost("register")]
        public async Task<Account> Register([FromBody] registerBody registerBody)
        {
            return await _authenticationService.Register(registerBody.Email, registerBody.Username, registerBody.Password, registerBody.ConfirmPassword);
        }

        public class registerBody
        {
            public string Email { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }
        }
    }
}
