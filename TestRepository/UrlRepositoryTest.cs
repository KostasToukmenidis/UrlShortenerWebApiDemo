using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.TestRepository
{
    public class UrlRepositoryTest : IUrlRepositoryTest
    {
        public List<Url> urls = new()
        {
            new Url { Id = 1, LongUrl = "http://www.youtube.com/wqeqweasqvf4wvf4vfxfv", ShortUrl = "http://www.youtube.com/abc", Token = "abc" },
            new Url { Id = 2, LongUrl = "http://www.youtube.com/213fw43ftdegrder5gv4e", ShortUrl = "http://www.youtube.com/efg", Token = "efg" },
            new Url { Id = 3, LongUrl = "http://www.youtube.com/wfaesfw43rw3vrf34wvfw", ShortUrl = "http://www.youtube.com/hjk", Token = "hjk" },
        };

        public List<Url> GetUrls()
        {
            return urls;
        }

        public Url GetUrl(int id)
        {
            return urls.Where(u => u.Id == id).FirstOrDefault();
        }

        public void CreateUrl(Url url)
        {
            urls.Add(url);
        }
    }
}
