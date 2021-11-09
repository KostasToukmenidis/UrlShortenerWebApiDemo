using System;
using System.Linq;
using UrlShortener.Data;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace URLShortener.Services
{
    public class UrlManager : IUrlManager
    {
        private readonly UrlShortenerDb _context;
        public UrlManager(UrlShortenerDb context)
        {
            _context = context;
        }

        public Url ShortenUrl(string longUrl)
        {
            string token = GenerateToken();

            Url url = new Url()
            {
                LongUrl = longUrl,
                Token = token,
                ShortUrl = "http://www.xcelsus.gr/" + token
            };

            if (_context.Urls.ToList().Exists(u=>u == url))
            {
                throw new Exception("URL already exists.");
            }

            _context.Urls.Add(url);
            _context.SaveChanges();

            return url;
        }

        public string GenerateToken()
        {
            for (int i = 0; i < 10; i++)
            {
                string token = Guid.NewGuid().ToString().Substring(0, 9);
                if (!_context.Urls.Any(u => u.Token == token))
                {
                    return token;
                }
            }

            return string.Empty;
        }
    }
}
