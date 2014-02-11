using Ramesoft.Cms.Common.DAL.Enums;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ramesoft.Cms.Filters
{
    public class SuperAdminOnlyAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!Roles.IsUserInRole(UserTypes.SuperAdmin.ToString()))
            {
                filterContext.Result = new HttpNotFoundResult("Requested URL not found.");
            }
        }
    }
}