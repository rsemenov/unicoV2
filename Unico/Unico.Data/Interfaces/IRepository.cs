using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Unico.Data.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        ISession Session { get; set; }

        IList<T> FindAll();
        T Find(Expression<Func<T, bool>> criteria);
        IList<T> FindAll(Expression<Func<T, bool>> criteria);
        void SaveOrUpdateAll(params T[] entities);
        void Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        public ISession Session { get; set; }

        public IQueryOver<T, T> QueryOver()
        {
            return Session.QueryOver<T>();
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            return Session
                .QueryOver<T>()
                .Where(criteria)
                .SingleOrDefault();
        }

        public IList<T> FindAll()
        {
            return Session
                .CreateCriteria<T>()
                .List<T>();
        }

        public IList<T> FindAll(Expression<Func<T, bool>> criteria)
        {
            return Session
                .QueryOver<T>()
                .Where(criteria)
                .List();
        }

        public void SaveOrUpdateAll(params T[] entities)
        {
            foreach (var item in entities)
            {
                Session.SaveOrUpdate(item);
            }
            Session.Flush();
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }
    }
}
