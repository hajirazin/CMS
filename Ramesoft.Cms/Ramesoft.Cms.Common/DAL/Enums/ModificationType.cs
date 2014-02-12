// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModificationType.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The modification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.DAL.Enums
{
    /// <summary>
    /// The modification type.
    /// </summary>
    public enum ModificationType
    {
        /// <summary>
        /// The update.
        /// </summary>
        Update = 'U', 

        /// <summary>
        /// The delete.
        /// </summary>
        Delete = 'D', 

        /// <summary>
        /// The add.
        /// </summary>
        Add = 'A'
    }
}