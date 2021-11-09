﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Dtos
{
    public class StatDto
    {
        public int Id { get; set; }
        public int UrlId { get; set; }
        public int Visits { get; set; } = 1;
        public DateTime Visited { get; set; } = DateTime.Now;
        public Url Url { get; set; }
    }
}
