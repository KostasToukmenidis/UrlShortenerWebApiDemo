using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Dtos;
using UrlShortener.Models;

namespace UrlShortener
{
    public static class Extensions
    {
        public static UrlDto AsUrlDto(this Url url)
        {
            return new UrlDto
            {
                Id = url.Id,
                LongUrl = url.LongUrl,
                ShortUrl = url.ShortUrl,
                Token = url.Token
            };
        }
    }
}
