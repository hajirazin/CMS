// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Ramesoft.Cms.Common.Models.Contract;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is duplicate.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <typeparam name="TList">
        /// List to check for duplicate
        /// </typeparam>
        /// <typeparam name="TValue">
        /// value to check for existence
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsDuplicate<TList, TValue>(this List<TList> list, Func<TList, TValue> predicate)
        {
            var hash = new HashSet<TValue>();
            return list.Select(predicate).Any(value => !hash.Add(value));
        }

        /// <summary>
        /// The partial list.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString PartialList(this HtmlHelper helper, string viewName)
        {
            return new MvcHtmlString(HttpUtility.JavaScriptStringEncode(helper.Partial(viewName).ToHtmlString()));
        }

        /// <summary>
        /// The to select list.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{SelectListItem}"/>.
        /// </returns>
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<ISelectable> items)
        {
            return items.Select(s => new SelectListItem { Text = s.Text, Value = s.Value });
        }

        #endregion
    }
}