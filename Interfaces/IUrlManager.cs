using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Interfaces
{
    public interface IUrlManager
    {
        Url ShortenUrl(string longUrl);
        string GenerateToken();
    }
}
