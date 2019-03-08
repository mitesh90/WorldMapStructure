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
    public class RoleDataCRUD
    {
        public void Insert(RoleData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.RoleData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(RoleData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.RoleData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(RoleData entity)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet table = context.RoleData;
                table.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<RoleData> SelectAll()
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<RoleData> table = context.Set<RoleData>();
                return table.ToList();
            }
        }

        public RoleData SelectById(object id)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                DbSet<RoleData> table = context.Set<RoleData>();
                return table.Find(id);
            }
        }

        public List<RoleData> Search(Expression<Func<RoleData, bool>> filter = null)
        {
            using (WorldMapDBContext context = new WorldMapDBContext())
            {
                if (filter == null)
                    return context.RoleData.ToList();
                return context.RoleData.Where(filter).ToList();
            }
        }

        public DbSet GetEntites()
        {
            WorldMapDBContext context = new WorldMapDBContext();
            return context.UserRoleMapping;
        }
    }
}
