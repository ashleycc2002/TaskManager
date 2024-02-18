using BLL.Tarea;
using Domainn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAPPTasks.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskCommandService<Tasks> _taskCmdService;
        private readonly ITaskQueryService<Tasks> _taskQueryService;


        public TaskController(ITaskCommandService<Tasks> cuentasAhorroCmdService, ITaskQueryService<Tasks> cuentasAhorroQueryService)
        {
            _taskCmdService = cuentasAhorroCmdService ?? throw new ArgumentException(nameof(cuentasAhorroCmdService));
            _taskQueryService = cuentasAhorroQueryService ?? throw new ArgumentException(nameof(cuentasAhorroQueryService));
        }
        // GET: CuentaAhorros
        public ActionResult Index()
        {
            var task = _taskQueryService.GetALL().ToList();
            return View(task);
        }

        // GET: CuentaAhorros/Details/5
        public ActionResult Details(int id)
        {
            var task = _taskQueryService.GetEntityById(id);
            return View(task);
        }

        // GET: CuentaAhorros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaAhorros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskCmdService.Add(entity);
                    return RedirectToAction("Index");
                }

                return View(entity);
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentaAhorros/Edit/5
        public ActionResult Edit(int id)
        {
            var task = _taskQueryService.GetEntityById(id);
            return View(task);
        }

        // POST: CuentaAhorros/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(Tasks entity)
        {
            try
            {
                _taskCmdService.Update(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentaAhorros/Delete/5
        public ActionResult Delete(int id)
        {
            var task = _taskQueryService.GetEntityById(id);
            return View(task);
        }

        // POST: CuentaAhorros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var task = _taskQueryService.GetEntityById(id);
                _taskCmdService.Remove(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
