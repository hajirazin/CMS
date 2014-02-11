// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The base repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.DAL.Factory
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="T">
    /// The type parameter
    /// </typeparam>
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        #region Fields

        /// <summary>
        ///     The data set.
        /// </summary>
        internal readonly DbSet<T> DataSet;

        /// <summary>
        /// The data context.
        /// </summary>
        internal readonly IEntityContext DataContext;

        /// <summary>
        /// The locker.
        /// </summary>
        private readonly object locker;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="dataContextObject">
        /// The data context object.
        /// </param>
        public BaseRepository(IEntityContext dataContextObject)
        {
            this.DataContext = dataContextObject;
            this.locker = new object();
            this.DataSet = this.DataContext.Set<T>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the get all.
        /// </summary>
        public virtual IQueryable<T> GetAll
        {
            get
            {
                return this.DataSet;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Add(T item)
        {
            this.DataSet.Add(item);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.DataContext.Dispose();
            this.disposed = true;
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Find(Func<T, bool> id)
        {
            return this.DataSet.FirstOrDefault(id);
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Find(Expression<Func<T, bool>> id)
        {
            return this.DataSet.FirstOrDefault(id);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Remove(T item)
        {
            this.DataSet.Remove(item);
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            lock (this.locker)
            {
                this.DataContext.SaveChanges();
            }
        }

        #endregion
    }
}