using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        TaskDbContext Context { get; }

        void Save();
    }
}
