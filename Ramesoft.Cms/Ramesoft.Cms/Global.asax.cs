using Castle.MicroKernel.Registration;
using Ramesoft.Cms.Common.Config;
using Ramesoft.Cms.Common.Logging;
using Ramesoft.Cms.Controllers;
using Ramesoft.Cms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ramesoft.Cms
{
    using Ramesoft.Cms.App_Start;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            DependencyResolver.SetResolver(new MyDependencyResolver());
            UnityConfig.Container.Register(Classes.FromAssemblyContaining<HomeController>().BasedOn<IController>().LifestyleTransient());
            MapConfig.CreateMaps();
            Logger.InitializeLogs(Server.MapPath("/Logs"));
            Logger.LogInfo("Application Started");
            //BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            //BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            try
            {
                Logger.LogException(Server.GetLastError(), "Error Caught in Application_Error");
            }
            catch
            {
            }

            Server.ClearError();
            Response.RedirectToRoute("Error");
        }
    }
}