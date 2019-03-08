using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class UserRoleMappingConfiguration : EntityTypeConfiguration<UserRoleMapping>
    {
        public UserRoleMappingConfiguration()
        {
            HasKey(p => p.UserRoleMappingId);
        }
    }
}
