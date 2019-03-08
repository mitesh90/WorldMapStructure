using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.DAL
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<WorldMapDBContext>
    {
        protected override void Seed(WorldMapDBContext context)
        {
            //GetCategories().ForEach(c => context.Categories.Add(c));
            //GetGadgets().ForEach(g => context.Gadgets.Add(g));

            context.Commit();
        }
    }
}
