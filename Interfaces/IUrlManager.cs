using UrlShortener.Models;

namespace UrlShortener.Interfaces
{
    public interface IUrlManager
    {
        Url ShortenUrl(string longUrl);
        string GenerateToken();
    }
}
