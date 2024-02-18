using DAL.GRepository;
using Domainn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tarea
{
    public class TaskQueryService : ITaskQueryService<Tasks>
    {

        private readonly IRepository<Tasks> _repository;

        public TaskQueryService(IRepository<Tasks> repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }
        public IEnumerable<Tasks> task { get; }
        public IList<Tasks> GeAll(bool intactive) => _repository.GetAll();

        public IList<Tasks> GetALL()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Tasks> GetAllList(bool intactive)
        {
            try
            {
                return _repository.GetEntity(intactive);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tasks GetEntityById(int id)
        {
            try
            {
                return _repository.GetSingle(x => x.Id.Equals(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tasks GetEntityByName(string name)
        {
            try
            {
                return _repository.GetSingle(x => x.Equals("hola"));
            }
            catch (Exception)
            {

                throw;
            }
        }
}   }   
