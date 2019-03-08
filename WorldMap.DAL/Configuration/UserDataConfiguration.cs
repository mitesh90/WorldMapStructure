using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.Configuration
{
    public class UserDataConfiguration : EntityTypeConfiguration<UserData>
    {
        public UserDataConfiguration()
        {
            ToTable("UserData");
            Property(c => c.UserName).IsRequired().HasMaxLength(50);
            HasKey(p => p.UserId);
        }
    }
}
