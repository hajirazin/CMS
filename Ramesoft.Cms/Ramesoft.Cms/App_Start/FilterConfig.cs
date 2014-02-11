using Ramesoft.Cms.Filters;
using System.Web;
using System.Web.Mvc;

namespace Ramesoft.Cms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyHandleErrorAttribute());
            filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }
}