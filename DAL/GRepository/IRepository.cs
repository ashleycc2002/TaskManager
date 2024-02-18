using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(params T[] items);
        void Remove(T entity);
        void Remove(params T[] items);
        void Update(T entity);
        void Update(params T[] items);
        void UpdateOne(T entity, Expression<Func<T, object>> propertyExpression);

        void SaveChanges();
        IQueryable<T> GetEntity(bool trackChanges = false);
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
