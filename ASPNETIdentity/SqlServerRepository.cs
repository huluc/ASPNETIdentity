using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ASPNETIdentity
{
    public class SqlServerRepository
    {
        public int Create<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (MyDbContext db = new MyDbContext())
            {
                //https://stackoverflow.com/questions/19130983/insert-operation-with-many-to-many-relationship-using-ef
                //if (entity is User user)
                //{
                //    db.Roles.Attach(user.Roles.FirstOrDefault());
                //}
                db.Set<TEntity>().Attach(entity);
                db.Set<TEntity>().Add(entity);


                return db.SaveChanges();
            }
        }
        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public int Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class, new()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return filter == null ?
                   db.Set<TEntity>().ToList() :
                   db.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}