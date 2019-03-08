using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.DAL
{
    public class GenericRepository<T> where T : class
    {
        public void Insert(T entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<T> table = context.Set<T>();
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<T> table = context.Set<T>();
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(T entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<T> table = context.Set<T>();
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<T> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<T> table = context.Set<T>();
                return table.ToList();
            }
        }

        public T SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<T> table = context.Set<T>();
                return table.Find(id);
            }
        }

        public List<T> Search(Expression<Func<T, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.Set<T>().ToList<T>();
                return context.Set<T>().Where<T>(filter).ToList<T>();
            }
        }

        public DbSet<T> GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.Set<T>();
        }
    }

}
