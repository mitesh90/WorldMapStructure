using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMap.DAL.Configuration;
using WorldMap.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WorldMap.DAL
{
    public class WorldMapDBContext : DbContext
    {
        public WorldMapDBContext() : base("WorldMapDBContext") { }

        public DbSet<CityData> CityData { get; set; }
        public DbSet<ContinentData> ContinentData { get; set; }
        public DbSet<CountryData> CountryData { get; set; }
        public DbSet<OverseasTerritoriesData> OverseasTerritoriesData { get; set; }
        public DbSet<RoleData> RoleData { get; set; }
        public DbSet<StateData> StateData { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserRoleMapping> UserRoleMapping { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CityDataConfiguration());
            modelBuilder.Configurations.Add(new ContinentDataConfiguration());
            modelBuilder.Configurations.Add(new CountryDataConfiguration());
            modelBuilder.Configurations.Add(new OverseasTerritoriesDataConfiguration());
            modelBuilder.Configurations.Add(new RoleDataConfiguration());
            modelBuilder.Configurations.Add(new StateDataConfiguration());
            modelBuilder.Configurations.Add(new UserDataConfiguration());
            modelBuilder.Configurations.Add(new UserRoleMappingConfiguration());
        }
    }
}
