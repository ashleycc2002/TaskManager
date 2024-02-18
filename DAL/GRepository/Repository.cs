using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TaskDbContext _context { get; }
        private readonly DbSet<T> _dbSet;

        public Repository(TaskDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception) { throw; }
        }

        public void Add(params T[] items)
        {
            try
            {
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Added;
                }

                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public IQueryable<T> GetEntity(bool trackChanges = false)
        {
            try
            {
                return trackChanges == false ? _context.Set<T>().AsNoTracking() : _context.Set<T>().AsQueryable<T>();
            }
            catch (Exception) { throw; }

        }

        public void Remove(T entity)
        {
            try
            {

                _context.Set<T>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(params T[] items)
        {
            try
            {
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(params T[] items)
        {
            try
            {
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdateOne(T entity, Expression<Func<T, object>> propertyExpression)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).Property(propertyExpression).IsModified = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            try
            {
                IQueryable<T> dbQuery = _context.Set<T>().AsQueryable<T>();
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                list = dbQuery.AsNoTracking().ToList<T>();
            }
            catch (Exception) { throw; }

            return list;
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            try
            {
                IQueryable<T> dbQuery = _context.Set<T>().AsQueryable<T>();

                dbQuery = navigationProperties.Aggregate(dbQuery,
                    (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                list = dbQuery.AsNoTracking().Where(where).ToList();
            }
            catch (Exception) { throw; }

            return list;
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            try
            {
                IQueryable<T> dbQuery = _context.Set<T>().AsQueryable<T>();

                //aplicando eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery,
                    (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                item = dbQuery.AsNoTracking().FirstOrDefault(where);

                if (item != null)
                {
                    _context.Set<T>().Attach(item);
                }
            }
            catch (Exception) { throw; }

            return item;
        }
    }
}
