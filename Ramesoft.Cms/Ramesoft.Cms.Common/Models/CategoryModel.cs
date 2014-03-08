// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryModel.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   The category model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Models
{
    using System.Globalization;

    using Ramesoft.Cms.Common.Models.Contract;

    /// <summary>
    ///     The category model.
    /// </summary>
    public class CategoryModel : ISelectable
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string CategoryName { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        ///     Gets the text.
        /// </summary>
        string ISelectable.Text
        {
            get
            {
                return this.CategoryName;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        string ISelectable.Value
        {
            get
            {
                return this.CategoryId.ToString(CultureInfo.InvariantCulture);
            }
        }

        #endregion
    }
}