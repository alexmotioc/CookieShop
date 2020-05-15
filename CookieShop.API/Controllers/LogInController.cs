using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogInController : ControllerBase
    {
        private readonly ILogger<LogInController> _logger;
        private readonly IAccountService _accountService;
        public LogInController(ILogger<LogInController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<Account> Post(string password, string email)
        {
            return await _accountService.GetByEmail(email);
        }
    }
}
