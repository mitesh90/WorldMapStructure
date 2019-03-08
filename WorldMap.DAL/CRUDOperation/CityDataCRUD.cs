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
    public class CityDataCRUD
    {
        public void Insert(CityData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.CityData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(CityData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.CityData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(CityData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.CityData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<CityData> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<CityData> table = context.Set<CityData>();
                return table.ToList();
            }
        }

        public CityData SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<CityData> table = context.Set<CityData>();
                return table.Find(id);
            }
        }

        public List<CityData> Search(Expression<Func<CityData, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.CityData.ToList();
                return context.CityData.Where(filter).ToList();
            }
        }

        public DbSet GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.CityData;
        }
    }
}
