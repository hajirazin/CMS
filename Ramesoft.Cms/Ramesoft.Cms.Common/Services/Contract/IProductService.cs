// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductService.cs" company="">
//   
// </copyright>
// <summary>
//   The ProductService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Services.Contract
{
    using System;
    using System.Collections.Generic;

    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;

    /// <summary>
    /// The ProductService interface.
    /// </summary>
    public interface IProductService : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// Gets the companies.
        /// </summary>
        IList<Company> Companies { get; }

        /// <summary>
        /// Gets the get products.
        /// </summary>
        List<ProductModel> GetProducts { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void Add(ProductModel product);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="products">
        /// The products.
        /// </param>
        void Add(IEnumerable<ProductModel> products);

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="ProductModel"/>.
        /// </returns>
        ProductModel Find(Func<ProductModel, bool> predicate);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void Remove(ProductModel product);

        #endregion
    }
}