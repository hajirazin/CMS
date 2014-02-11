// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//   
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Newtonsoft.Json.Schema;

    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Implementation;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Services.Contract;
    using Ramesoft.Cms.Filters;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Fields

        /// <summary>
        /// The common repository.
        /// </summary>
        private readonly CommonRepositories commonRepository;

        /// <summary>
        /// The log repository.
        /// </summary>
        private readonly IRepository<Log> logRepository;

        /// <summary>
        /// The product service.
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        /// <param name="productService">
        /// The product service.
        /// </param>
        /// <param name="commonRepository">
        /// The common repository.
        /// </param>
        public HomeController(
            IUnitOfWork unitOfWork, 
            IProductService productService, 
            CommonRepositories commonRepository)
        {
            this.logRepository = unitOfWork.GetStanderdRepository<Log>();
            this.productService = productService;
            this.commonRepository = commonRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The about.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";

            return this.View();
        }

        /// <summary>
        /// The contact.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View("Products", this.productService.GetProducts);
        }

        /// <summary>
        /// The logs.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [SuperAdminOnly]
        public ActionResult Logs()
        {
            return this.View("Logs", this.logRepository.GetAll.OrderByDescending(l => l.LogId).ToList());
        }

        /// <summary>
        /// The SQL.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [SuperAdminOnly]
        public ActionResult SQL()
        {
            return this.View();
        }

        /// <summary>
        /// The SQL.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [SuperAdminOnly]
        public ActionResult SQL(string command)
        {
            this.commonRepository.ExecuteCommand(command);
            return this.RedirectToAction("Index");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.logRepository.Dispose();
            this.productService.Dispose();
            this.commonRepository.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}