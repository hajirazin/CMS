// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The UnitOfWork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.DAL.Repository
{
    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        IEntityContext DataContext { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetRepository<T>() where T : class;

        /// <summary>
        /// The get standerd repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRepository"/>.
        /// </returns>
        IRepository<T> GetStanderdRepository<T>() where T : class;

        /// <summary>
        /// The save.
        /// </summary>
        void Save();

        #endregion
    }
}