// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The repository provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Ramesoft.Cms.Common.DAL.Factory
{
    using System;
    using System.Collections.Generic;

    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    ///     The repository provider.
    /// </summary>
    public class RepositoryProvider : IRepositoryProvider
    {
        #region Fields

        /// <summary>
        ///     The dictionary.
        /// </summary>
        private readonly Dictionary<Type, object> dictionary;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RepositoryProvider" /> class.
        /// </summary>
        public RepositoryProvider()
        {
            this.dictionary = new Dictionary<Type, object>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the data context.
        /// </summary>
        public IEntityContext DataContext { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The get repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public T GetRepository<T>() where T : class
        {
            object value;
            this.dictionary.TryGetValue(typeof(T), out value);
            return (T)value ?? this.MakeRepository<T>();
        }

        /// <summary>
        ///     The get standerd repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IRepository" />.
        /// </returns>
        public IRepository<T> GetStanderdRepository<T>() where T : class
        {
            object value;
            this.dictionary.TryGetValue(typeof(T), out value);
            return (IRepository<T>)value ?? this.MakeStanderdRepository<T>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The make repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        private T MakeRepository<T>() where T : class
        {
            Func<IEntityContext, object> predicate = RepositoryFactory.GetRepositoryFactory<T>();
            object value = predicate(this.DataContext);
            this.dictionary.Add(typeof(T), value);
            return (T)value;
        }

        /// <summary>
        ///     The make standerd repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IRepository" />.
        /// </returns>
        private IRepository<T> MakeStanderdRepository<T>() where T : class
        {
            Func<IEntityContext, IRepository<T>> predicate = RepositoryFactory.GetStanderdRepository<T>();
            IRepository<T> value = predicate(this.DataContext);
            this.dictionary.Add(typeof(T), value);
            return value;
        }

        #endregion
    }
}