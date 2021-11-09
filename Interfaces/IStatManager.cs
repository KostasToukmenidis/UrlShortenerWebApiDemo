using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Interfaces
{
    public interface IStatManager
    {
        void CreateStat(int urlId);
    }
}
