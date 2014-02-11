// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MigrationConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The migration configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Config
{
    using System.Data.Entity.Migrations;

    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    /// The migration configuration.
    /// </summary>
    public class MigrationConfiguration : DbMigrationsConfiguration<EntityContext>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationConfiguration"/> class.
        /// </summary>
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        #endregion
    }
}