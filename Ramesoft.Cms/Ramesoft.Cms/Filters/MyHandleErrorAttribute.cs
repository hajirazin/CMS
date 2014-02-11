using Ramesoft.Cms.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ramesoft.Cms.Filters
{
    public class MyHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger.LogException(filterContext.Exception, "Error Caught in filter");
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectToRouteResult("Error", null);
        }
    }
}