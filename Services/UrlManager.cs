using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Services;

namespace URLShortener.Services
{
    public class UrlManager
    {
        private readonly UrlShortenerDb _context;
        private StatManager _stat;
        public UrlManager(UrlShortenerDb context, StatManager stat)
        {
            _context = context;
            _stat = stat;
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

        private string GenerateToken()
        {
            for (int i = 0; i < 30; i++)
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
