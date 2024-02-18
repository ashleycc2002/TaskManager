using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tasks
{
    public interface ITaskCommandService<T> where T : class
    {
        void Add(T entity);
        void Add(params T[] items);
        void Remove(T entity);
        void Remove(params T[] items);
        void Update(T entity);
        void Update(params T[] items);
      
       
    }
}
