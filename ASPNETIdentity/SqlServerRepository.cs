using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ASPNETIdentity
{
    public class SqlServerRepository
    {
        public int Create<TEntity>(TEntity entity) where TEntity:class,new()
        {
            using (MyDbContext db = new MyDbContext())
            {
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
        public List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter=null) where TEntity : class, new()
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