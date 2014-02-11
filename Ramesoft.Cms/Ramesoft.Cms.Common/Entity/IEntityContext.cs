// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityContext.cs" company="">
//   
// </copyright>
// <summary>
//   The EntityContext interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;

    /// <summary>
    /// The EntityContext interface.
    /// </summary>
    public interface IEntityContext : IDisposable, IObjectContextAdapter
    {
        #region Public Properties

        /// <summary>
        /// Gets the change tracker.
        /// </summary>
        DbChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Gets the database.
        /// </summary>
        Database Database { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The entry.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbEntityEntry"/>.
        /// </returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// The entry.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="DbEntityEntry"/>.
        /// </returns>
        DbEntityEntry Entry(object entity);

        /// <summary>
        /// The get validation errors.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<DbEntityValidationResult> GetValidationErrors();

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// The set.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/>.
        /// </returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="entityType">
        /// The entity type.
        /// </param>
        /// <returns>
        /// The <see cref="DbSet"/>.
        /// </returns>
        DbSet Set(Type entityType);

        #endregion
    }
}