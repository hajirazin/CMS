// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogsController.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The logs controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Filters;

    /// <summary>
    /// The logs controller.
    /// </summary>
    [SuperAdminOnly]
    public class LogsController : Controller
    {
        #region Fields

        /// <summary>
        /// The log repository.
        /// </summary>
        private readonly IRepository<Log> logRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsController"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public LogsController(IUnitOfWork unitOfWork)
        {
            this.logRepository = unitOfWork.GetStanderdRepository<Log>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The details.
        /// </summary>
        /// <param name="logId">
        /// The log id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Details(int logId)
        {
            return this.View(this.logRepository.Find(i => i.LogId == logId));
        }

        /// <summary>
        /// The get logs.
        /// </summary>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult GetLogs(int pageNumber)
        {
            return
                this.Json(
                    this.logRepository.GetAll.OrderByDescending(i => i.LogId)
                        .Skip((pageNumber - 1) * 5)
                        .Take(5)
                        .ToList());
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View("Logs", this.logRepository.GetAll.OrderByDescending(l => l.LogId).Take(5).ToList());
        }

        #endregion
    }
}