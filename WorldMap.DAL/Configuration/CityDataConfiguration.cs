using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class CityDataConfiguration : EntityTypeConfiguration<CityData>
    {
        public CityDataConfiguration()
        {
            ToTable("CityData");
            Property(c => c.CityName).IsRequired().HasMaxLength(50);
            HasKey(p => p.CityId);
        }
    }
}
