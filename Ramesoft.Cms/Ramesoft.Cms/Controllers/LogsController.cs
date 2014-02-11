using Ramesoft.Cms.Common.DAL.Factory;
using Ramesoft.Cms.Common.DAL.Implementation;
using Ramesoft.Cms.Common.DAL.Repository;
using Ramesoft.Cms.Common.Entity;
using Ramesoft.Cms.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ramesoft.Cms.Controllers
{
    [SuperAdminOnly]
    public class LogsController : Controller
    {
        private IUnitOfWork unitOfWork;

        private IRepository<Log> logRepository;

        public LogsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.logRepository = unitOfWork.GetStanderdRepository<Log>();
        }

        public ActionResult Index()
        {
            return View("Logs", this.logRepository.GetAll.OrderByDescending(l => l.LogId).Take(5).ToList());
        }

        public ActionResult Details(int logId)
        {
            return this.View(this.logRepository.Find(i => i.LogId == logId));
        }

        [HttpPost]
        public JsonResult GetLogs(int pageNumber)
        {
            return this.Json(this.logRepository.GetAll.OrderByDescending(i => i.LogId).Skip((pageNumber - 1) * 5).Take(5).ToList());
        }
    }
}
