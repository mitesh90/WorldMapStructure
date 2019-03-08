using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.DAL
{
    public class DbFactory : Disposable, IDbFactory
    {
        WorldMapDBContext dbContext;

        public WorldMapDBContext Init()
        {
            return dbContext ?? (dbContext = new WorldMapDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
