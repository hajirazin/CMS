// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The unit of work.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.DAL.Implementation
{
    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        /// The repository provider.
        /// </summary>
        private readonly IRepositoryProvider repositoryProvider;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="repositoryProvider">
        /// The repository provider.
        /// </param>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        public UnitOfWork(IRepositoryProvider repositoryProvider, IEntityContext dataContext)
        {
            this.repositoryProvider = repositoryProvider;
            this.DataContext = dataContext;
            this.repositoryProvider.DataContext = dataContext;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        public IEntityContext DataContext { get; set; }

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
        public T GetRepository<T>() where T : class
        {
            return this.repositoryProvider.GetRepository<T>();
        }

        /// <summary>
        /// The get standerd repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRepository"/>.
        /// </returns>
        public IRepository<T> GetStanderdRepository<T>() where T : class
        {
            return this.repositoryProvider.GetStanderdRepository<T>();
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            this.DataContext.SaveChanges();
        }

        #endregion
    }
}