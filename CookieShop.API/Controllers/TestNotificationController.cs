using CookieShop.API.Services;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TestNotificationController : ControllerBase
    {
        private readonly Notify _notificationService;


        public TestNotificationController(Notify notificationService)
            {
            _notificationService = notificationService;
            }

        [HttpGet("test")]
        public  async Task<bool> AddFavorite()
        {

            await _notificationService.Send("Updated Stock!");
            return true;

      
        }

    }
}
