using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class CountryDataConfiguration : EntityTypeConfiguration<CountryData>
    {
        public CountryDataConfiguration()
        {
            //ToTable("ContinentData");
            Property(c => c.CountryName).IsRequired().HasMaxLength(50);
            Property(c => c.CountryCapital).IsRequired().HasMaxLength(50);
            HasKey(p => p.CountryId);
        }
    }
}
