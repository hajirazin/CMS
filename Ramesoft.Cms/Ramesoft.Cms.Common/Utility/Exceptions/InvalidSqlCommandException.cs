// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidSqlCommandException.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The invalid sql command exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Utility.Exceptions
{
    using System;

    /// <summary>
    /// The invalid SQL command exception.
    /// </summary>
    public class InvalidSqlCommandException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSqlCommandException"/> class.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public InvalidSqlCommandException(Exception ex)
            : base("Sql Command is not Valid", ex)
        {
        }

        #endregion
    }
}