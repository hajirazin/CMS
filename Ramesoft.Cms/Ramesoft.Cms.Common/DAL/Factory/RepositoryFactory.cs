// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The repository factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Ramesoft.Cms.Common.DAL.Factory
{
    using System;
    using System.Collections.Generic;

    using Ramesoft.Cms.Common.Config;
    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    ///     The repository factory.
    /// </summary>
    public static class RepositoryFactory
    {
        #region Static Fields

        /// <summary>
        ///     The dictionary.
        /// </summary>
        private static readonly IDictionary<Type, Func<IEntityContext, object>> dictionary =
            new Dictionary<Type, Func<IEntityContext, object>>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The get repository factory.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="Func" />.
        /// </returns>
        public static Func<IEntityContext, object> GetRepositoryFactory<T>() where T : class
        {
            Func<IEntityContext, object> value;
            dictionary.TryGetValue(typeof(T), out value);
            return value ?? AddNewValueToDictionary<T>();
        }

        /// <summary>
        ///     The get standerd repository.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="Func" />.
        /// </returns>
        public static Func<IEntityContext, IRepository<T>> GetStanderdRepository<T>() where T : class
        {
            return c => new BaseRepository<T>(c);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The add new value to dictionary.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="Func" />.
        /// </returns>
        private static Func<IEntityContext, object> AddNewValueToDictionary<T>() where T : class
        {
            Func<IEntityContext, object> value =
                i => UnityConfig.Resolve<T>(new Dictionary<string, IEntityContext> { { "dbObject", i } });
            dictionary.Add(typeof(T), value);
            return value;
        }

        #endregion
    }
}