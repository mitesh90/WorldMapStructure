using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class ContinentDataConfiguration : EntityTypeConfiguration<ContinentData>
    {
        public ContinentDataConfiguration()
        {
            //ToTable("ContinentData");
            Property(c => c.ContinentName).IsRequired().HasMaxLength(50);
            HasKey(p => p.ContinentId);
        }
    }
}
