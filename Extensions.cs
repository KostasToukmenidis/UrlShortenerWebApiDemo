using UrlShortener.Dtos;
using UrlShortener.Models;

namespace UrlShortener
{
    public static class Extensions
    {
        //Converting Url object to UrlDtoObject
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

        //Making URL passed by the user look like an actual URL
        public static string UrlCorrect(this string longUrl)
        {
            string correctUrl = string.Empty;
            if (!longUrl.StartsWith("http://www.") && !longUrl.Contains("www."))
                correctUrl = "http://www." + longUrl;
            else if (longUrl.StartsWith("www."))
                correctUrl = "http://" + longUrl;
            else
                correctUrl = longUrl;

            return correctUrl;
        }
    }
}
