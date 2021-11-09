using System.Linq;
using UrlShortener.Data;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class StatManager :IStatManager
    {
        private readonly UrlShortenerDb _context;
        public StatManager(UrlShortenerDb context)
        {
            _context = context;
        }

        public void CreateStat(int urlId)
        {
            var urls = _context.Urls.ToList();
             Stat stat = new Stat 
             {
                UrlId = urlId,
                Visits = urls.Count
             };
            _context.Stats.Add(stat);
            _context.SaveChanges();
        }
    }
}
