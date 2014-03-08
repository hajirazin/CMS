// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Ramesoft.Cms.Common.DAL.Factory
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type parameter
    /// </typeparam>
    public interface IRepository<T> : IDisposable
    {
        #region Public Properties

        /// <summary>
        ///     Gets the get all.
        /// </summary>
        IQueryable<T> GetAll { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        void Add(T log);

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Find(Func<T, bool> id);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Remove(T item);

        /// <summary>
        ///     The save.
        /// </summary>
        void Save();

        #endregion
    }
}