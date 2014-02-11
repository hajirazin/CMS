// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonRepositories.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The common repositories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.DAL.Implementation
{
    using System;

    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Utility.Exceptions;

    /// <summary>
    /// The common repositories.
    /// </summary>
    public class CommonRepositories : IDisposable
    {
        #region Fields

        /// <summary>
        /// The database.
        /// </summary>
        private readonly IEntityContext db;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRepositories"/> class.
        /// </summary>
        /// <param name="db">
        /// The database.
        /// </param>
        public CommonRepositories(IEntityContext db)
        {
            this.db = db;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The dispose.
        /// </summary>
        public virtual void Dispose()
        {
            this.db.Dispose();
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="InvalidSqlCommandException">
        /// The Invalid SQL Command Exception
        /// </exception>
        public virtual int ExecuteCommand(string command)
        {
            try
            {
                return this.db.Database.ExecuteSqlCommand(command);
            }
            catch (Exception e)
            {
                throw new InvalidSqlCommandException(e);
            }
        }

        #endregion
    }
}