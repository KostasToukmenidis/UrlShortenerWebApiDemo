using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Dtos;
using UrlShortener.Interfaces;
using UrlShortener.Models;
using UrlShortener.Services;
using UrlShortener.TestRepository;
using URLShortener.Services;

namespace UrlShortener.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlManager _urlManager;
        private readonly IStatManager _statManager;

        public UrlController(IUrlManager urlManager, IStatManager statManager)
        {
            _urlManager = urlManager;
            _statManager = statManager;
        }

        [HttpPost]
        public ActionResult<string> Post(string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
                return NotFound();

            longUrl.UrlCorrect();

            if (ModelState.IsValid)
            {
                var url = _urlManager.ShortenUrl(longUrl).AsUrlDto();
                _statManager.CreateStat(url.Id);
                
                return url.ShortUrl;
            }

            return NotFound();
        }
    }
}
