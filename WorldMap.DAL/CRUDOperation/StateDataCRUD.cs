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
    public class StateDataCRUD
    {
        public void Insert(StateData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.StateData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(StateData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.StateData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(StateData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.StateData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<StateData> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<StateData> table = context.Set<StateData>();
                return table.ToList();
            }
        }

        public StateData SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<StateData> table = context.Set<StateData>();
                return table.Find(id);
            }
        }

        public List<StateData> Search(Expression<Func<StateData, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.StateData.ToList();
                return context.StateData.Where(filter).ToList();
            }
        }

        public DbSet GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.StateData;
        }
    }
}
