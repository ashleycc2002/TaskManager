using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tasks
{
    public interface ITaskQueryService<T> where T : class
    {
        IEnumerable<T> Task { get; }
        T GetEntityById(int id);
        IList<T> GetEntitity();
        IList<T> GetALL();
        IQueryable<T> GetAllList(bool intactive);
        T GetEntityByName(string name);
        
    }
}
