using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Dtos;
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
        private readonly IUrlRepositoryTest urlRepo;
        private readonly UrlManager _urlManager;
        private readonly StatManager _statManager;

        public UrlController(IUrlRepositoryTest urlRepository, UrlManager urlManager, StatManager statManager)
        {
            urlRepo = urlRepository;
            _urlManager = urlManager;
            _statManager = statManager;
        }

        //[HttpGet]
        //public IEnumerable<UrlDto> GetUrls()
        //{
        //    var urls = urlRepo.GetUrls().Select(url => url.AsUrlDto());
        //    return urls;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<UrlDto> GetUrl(int id)
        //{
        //    var url = urlRepo.GetUrl(id);
        //    if (url != null)
        //        return url.AsUrlDto();
        //    else return NotFound();
        //}

        //[HttpPost]
        //public ActionResult<CreateUrlDto> CreateUrl(CreateUrlDto urldto)
        //{
        //    Url url = new Url
        //    {
        //        Id = urldto.Id,
        //        LongUrl = urldto.LongUrl,
        //        ShortUrl = urldto.ShortUrl,
        //        Token = urldto.Token
        //    };
        //    urlRepo.CreateUrl(url);
        //    return CreatedAtAction(nameof(GetUrl), new { id = url.Id }, url.AsUrlDto());
        //}
        //------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult<UrlDto> Get()
        {
            var urlDto = new UrlDto();
            return urlDto;
        }

        [HttpPost]
        public ActionResult<string> Post(string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
                return NotFound();

            if (!longUrl.StartsWith("http://www.") && !longUrl.Contains("www."))
                longUrl = "http://www." + longUrl;
            else if (longUrl.StartsWith("www."))
                longUrl = "http://" + longUrl;

            if (ModelState.IsValid)
            {
                var url = _urlManager.ShortenUrl(longUrl);
                _statManager.CreateStat(url.Id);
                return url.ShortUrl;
            }

            return NotFound();
        }
    }
}
