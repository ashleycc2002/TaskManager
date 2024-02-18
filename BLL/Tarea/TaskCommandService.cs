using DAL.GRepository;
using Domainn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tarea
{
    public class TaskCommandService : ITaskCommandService<Tasks>
    {
        private readonly IRepository<Tasks> _repository;

        public TaskCommandService(IRepository<Tasks> repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public void Add(Tasks entity)
        {
            try
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Add(params Tasks[] items)
        {
            try
            {
                _repository.Add(items);
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Remove(Tasks entity)
        {
            try
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(params Tasks[] items)
        {
            try
            {
                _repository.Remove(items);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(Tasks entity)
        {
            try
            {
                var tasks = _repository.GetAll().FirstOrDefault(x => x.Id.Equals(entity.Id));

                tasks.Id = entity.Id;
                tasks.Descripcion= entity.Descripcion;
                tasks.FechaDecreacion = entity.FechaDecreacion;
                tasks.Estado = entity.Estado;
                tasks.Prioridad = entity.Prioridad;

                _repository.Update(tasks);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    

        public void Update(params Tasks[] items)
        {
            try
            {
                var newcastle = new List<Tasks>();

                var tasks = _repository.GetAll().FirstOrDefault(x => x.Id.Equals(items[0].Id));

                foreach (var itm in items)
                {
                    if (tasks == null) continue;
                    tasks.Id = itm.Id;
                    tasks.Descripcion = itm.Descripcion;
                    tasks.FechaDecreacion = itm.FechaDecreacion;
                    tasks.Estado = itm.Estado;
                    tasks.Prioridad = itm.Prioridad;
                    
                }

                newcastle.Add(tasks);

                _repository.Update(newcastle.ToArray());
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}  