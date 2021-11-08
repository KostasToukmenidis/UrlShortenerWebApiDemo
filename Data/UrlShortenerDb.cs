using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class UrlShortenerDb : DbContext
    {
        public UrlShortenerDb(DbContextOptions<UrlShortenerDb> options) : base(options) { }
        
        public virtual DbSet<Url> Urls { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
    }
}
