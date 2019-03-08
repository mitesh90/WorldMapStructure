using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class OverseasTerritoriesDataConfiguration : EntityTypeConfiguration<OverseasTerritoriesData>
    {
        public OverseasTerritoriesDataConfiguration()
        {
            ToTable("OverseasTerritoriesData");
            Property(c => c.OverseasTerritoriesName).IsRequired().HasMaxLength(50);
            HasKey(p => p.OverseasTerritoriesId);
        }
    }
}
