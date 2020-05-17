using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookieShop.API.Services;
using CookieShop.Domain.Models;
using CookieShop.Domain.Services;
using CookieShop.Domain.Services.AuthenticationServices;
using CookieShop.EntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CookieShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : ControllerBase
    {
        private readonly ILogger<CookieController> _logger;
        private readonly ICookieService _cookieService;

        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public CookieController(ILogger<CookieController> logger, ICookieService cookieService, ITokenService tokenService, IMapper mapper)
        {
            _logger = logger;
            _cookieService = cookieService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IEnumerable<Cookie>> GetAll([FromQuery]GetCookieRequest loginBody)
        {
            var CookieList = await _cookieService.GetAll(loginBody.Name, loginBody.Type, loginBody.Price, loginBody.Sweeteners,loginBody.Rating);
            //var model = _mapper.Map<IList<CookieResponse>>(CookieList);

            return CookieList;
        }

        //type, price, quantity of sweeteners


        public class GetCookieRequest
        {
            public string Name { get; set; }
            public CookieType? Type { get; set; }
            public int? Price { get; set; }
            public int? Sweeteners { get; set; }
            public int? Rating { get; set; }
        }

        [HttpPost()]
        public async Task<CookieResponse> Create([FromBody] CreateCookieRequest createCookieRequest)
        {
            var cookie =  await _cookieService.Create(
                new Cookie
                {
                    Name = createCookieRequest.Name,
                    Type = createCookieRequest.Type,
                    Price = createCookieRequest.Price,
                    Sweeteners = createCookieRequest.Sweeteners,
                    Stock = new Stock { Amount = 0 }
                });
            var model = _mapper.Map<CookieResponse>(cookie);
            return model;
        }

        [HttpPost("rate")]
        public async Task<CookieRating> AddRatings([FromBody]RatingBody ratingBody)
        {
            var cookie = await _cookieService.AddRatings(2,ratingBody.cookieId, ratingBody.rating);

            
            //var model = _mapper.Map<CookieResponse>(cookie);
            return cookie;
        }

        public class RatingBody
        {
            public int cookieId { get; set; }
            public int rating { get; set; }
        }
        public class CreateCookieRequest
        {
            public string Name { get; set; }
            public CookieType Type { get; set; }
            public int Price { get; set; }
            public int Sweeteners { get; set; }
        }
    }
}
