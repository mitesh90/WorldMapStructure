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
    public class UserDataCRUD
    {
        public void Insert(UserData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.UserData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(UserData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.UserData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(UserData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.UserData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<UserData> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<UserData> table = context.Set<UserData>();
                return table.ToList();
            }
        }

        public UserData SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<UserData> table = context.Set<UserData>();
                return table.Find(id);
            }
        }

        public List<UserData> Search(Expression<Func<UserData, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.UserData.ToList();
                return context.UserData.Where(filter).ToList();
            }
        }

        public DbSet GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.UserData;
        }
    }
}
