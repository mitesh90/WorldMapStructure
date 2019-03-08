using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.DAL
{
    public interface IDbFactory : IDisposable
    {
        WorldMapDBContext Init();
    }
}
