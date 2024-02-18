using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tarea
{
    public interface ITaskQueryService<T> where T : class
    {
        IEnumerable<T> task { get; }
        T GetEntityById(int id);
        IList<T> GetALL();
        IQueryable<T> GetAllList(bool intactive);
        T GetEntityByName(string name);
    }
}
