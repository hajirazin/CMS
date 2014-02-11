using Ramesoft.Cms.Common.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ramesoft.Cms.Utility
{
    public static class Extensions
    {
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<ISelectable> items)
        {
            return items.Select(s => new SelectListItem
                                       {
                                           Text = s.Text,
                                           Value = s.Value
                                       });
        }

        public static MvcHtmlString PartialList(this HtmlHelper helper, string viewName)
        {
            return new MvcHtmlString(HttpUtility.JavaScriptStringEncode(helper.Partial(viewName).ToHtmlString()));
        }

        public static bool IsDuplicate<TList, TValue>(this List<TList> list, Func<TList, TValue> predicate)
        {
            var hash = new HashSet<TValue>();
            foreach (var product in list)
            {
                var value = predicate(product);
                if (!hash.Add(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}