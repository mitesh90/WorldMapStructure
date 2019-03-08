using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class StateDataConfiguration : EntityTypeConfiguration<StateData>
    {
        public StateDataConfiguration()
        {
            ToTable("StateData");
            Property(c => c.StateCapital).IsRequired().HasMaxLength(50);
            Property(c => c.StateName).IsRequired().HasMaxLength(50);
            HasKey(p => p.StateId);
        }
    }
}
