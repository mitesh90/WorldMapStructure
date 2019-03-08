using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class RoleDataConfiguration : EntityTypeConfiguration<RoleData>
    {
        public RoleDataConfiguration()
        {
            ToTable("RoleData");
            Property(c => c.RoleName).IsRequired().HasMaxLength(50);
            HasKey(p => p.RoleId);
        }
    }
}
