using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorldMap.Model;

namespace WorldMap.DAL.CRUDOperation
{
    public class OverseasTerritoriesDataCRUD
    {
        public void Insert(OverseasTerritoriesData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.OverseasTerritoriesData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(OverseasTerritoriesData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.OverseasTerritoriesData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(OverseasTerritoriesData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.OverseasTerritoriesData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<OverseasTerritoriesData> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<OverseasTerritoriesData> table = context.Set<OverseasTerritoriesData>();
                return table.ToList();
            }
        }

        public OverseasTerritoriesData SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<OverseasTerritoriesData> table = context.Set<OverseasTerritoriesData>();
                return table.Find(id);
            }
        }

        public List<OverseasTerritoriesData> Search(Expression<Func<OverseasTerritoriesData, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.OverseasTerritoriesData.ToList();
                return context.OverseasTerritoriesData.Where(filter).ToList();
            }
        }

        public DbSet GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.OverseasTerritoriesData;
        }
    }
}
