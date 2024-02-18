using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        public TaskDbContext Context { get; }

        TaskDbContext IUnitOfWork.Context => throw new NotImplementedException();

        public UnitOfWork(TaskDbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
