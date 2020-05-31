using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CookieShop.API.Services;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using CookieShop.Domain.Services.AuthenticationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly ILogger<AuthentificationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        private readonly ITokenService _tokenService;

        public AuthentificationController(ILogger<AuthentificationController> logger, IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<LoginResponse> Login([FromBody] LoginBody loginBody)
        {
            var Account = await _authenticationService.Login(loginBody.Email, loginBody.Password);
            if (Account == null)
            {
                return null;

            }
            else
            {

                return new LoginResponse
                {
                    Token = _tokenService.CreateToken(Account.Id, Account.Role),
                    Role = Account.Role.ToString(), 
                    Balance = Account.Balance,
                    Name = loginBody.Email
                };
            }



        }

    public class LoginResponse
    {
        public string Token { get; set; }
        public string Role { get; set; }
            public double Balance { get; set; }
            public string Name { get; set; }
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
