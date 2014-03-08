// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   The mvc application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.MicroKernel.Registration;

    using Ramesoft.Cms.App_Start;
    using Ramesoft.Cms.Common.Config;
    using Ramesoft.Cms.Common.Logging;
    using Ramesoft.Cms.Controllers;
    using Ramesoft.Cms.Models;

    /// <summary>
    /// The MVC application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        ///     The application_ error.
        /// </summary>
        protected void Application_Error()
        {
            try
            {
                Logger.LogException(this.Server.GetLastError(), "Error Caught in Application_Error");
            }
                
                // ReSharper disable EmptyGeneralCatchClause
            catch
            {
                // ReSharper restore EmptyGeneralCatchClause
            }

            this.Server.ClearError();
            this.Response.RedirectToRoute("Error");
        }

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            DependencyResolver.SetResolver(new MyDependencyResolver());
            UnityConfig.Container.Register(
                Classes.FromAssemblyContaining<HomeController>().BasedOn<IController>().LifestyleTransient());
            MapConfig.CreateMaps();
            Logger.InitializeLogs(this.Server.MapPath("/Logs"));
            Logger.LogInfo("Application Started");
        }

        #endregion
    }
}