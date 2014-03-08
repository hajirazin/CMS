// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Controllers
{
    using System.Web.Mvc;

    using Ramesoft.Cms.Common.DAL.Implementation;
    using Ramesoft.Cms.Common.Utility;
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
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="commonRepository">
        /// The common repository.
        /// </param>
        public HomeController( 
            CommonRepositories commonRepository)
        {
            this.commonRepository = commonRepository;
        }

        #endregion

        #region Public Methods and Operators

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
            this.TempData[Constants.SQLSuccess] = @"Command Executed successfully";
            return this.View();
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

            this.commonRepository.Dispose();
            base.Dispose(disposing);
            this.disposed = true;
        }

        #endregion
    }
}