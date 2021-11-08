using System.Collections.Generic;
using UrlShortener.Models;

namespace UrlShortener.TestRepository
{
    public interface IUrlRepositoryTest
    {
        Url GetUrl(int id);
        List<Url> GetUrls();
        void CreateUrl(Url url);
    }
}