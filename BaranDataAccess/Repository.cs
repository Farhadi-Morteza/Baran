using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaranDataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AMSEntities DatabaseContext;
        internal DbSet<T> DbSet;

        public Repository(AMSEntities db)
        {
            DatabaseContext = db;
            DbSet = DatabaseContext.Set<T>();
        }
        public void Delete(T entity)
        {
            if (DatabaseContext.Entry(entity).State == System.Data.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DatabaseContext.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual bool DeleteById(object id)
        {
            T entity = GetById(id);

            if (entity == null)
            {
                return false;
            }

            Update(entity);
            return true;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = DbSet.ToList();

            return result;
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null)
        {
            //Laizy loading 
            IQueryable<T> query = DbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            var result = query.ToList();

            return result;
        }

        public virtual T GetById(object id)
        {
            return DbSet.Find(keyValues: id);
        }

        public virtual void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (DatabaseContext.Entry(entity).State == System.Data.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DatabaseContext.Entry(entity).State = System.Data.EntityState.Modified;
        }
    }
}
