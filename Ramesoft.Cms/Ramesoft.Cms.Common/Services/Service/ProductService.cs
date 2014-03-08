// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductService.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   The product service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Services.Service
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;
    using Ramesoft.Cms.Common.Services.Contract;

    /// <summary>
    /// The product service.
    /// </summary>
    public class ProductService : IProductService
    {
        #region Fields

        /// <summary>
        /// The product repository.
        /// </summary>
        private readonly IRepository<Product> productRepository;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = unitOfWork.GetStanderdRepository<Product>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the companies.
        /// </summary>
        public IList<Company> Companies
        {
            get
            {
                var query = this.unitOfWork.DataContext.Set<Company>();
                query.Load();
                return query.Local;
            }
        }

        /// <summary>
        /// Gets the get products.
        /// </summary>
        public List<ProductModel> GetProducts
        {
            get
            {
                var product =
                    this.productRepository.GetAll.Select(
                        p =>
                        new ProductModel
                            {
                                SubCatagoryName = p.Category.CategoryName, 
                                ProductName = p.ProductName, 
                                ProductId = p.ProductID, 
                                CatagoryName = p.Category.Category2.CategoryName
                            });

                return product.ToList();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void Add(ProductModel product)
        {
            this.productRepository.Add(Mapper.Map<Product>(product));
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="products">
        /// The products.
        /// </param>
        public void Add(IEnumerable<ProductModel> products)
        {
            foreach (var product in products)
            {
                this.productRepository.Add(Mapper.Map<Product>(product));
            }

            this.unitOfWork.Save();
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

            this.productRepository.Dispose();
            this.disposed = true;
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="ProductModel"/>.
        /// </returns>
        public ProductModel Find(Func<ProductModel, bool> predicate)
        {
            return
                Mapper.Map<Product, ProductModel>(
                    this.productRepository.Find(i => predicate(Mapper.Map<Product, ProductModel>(i))));
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void Remove(ProductModel product)
        {
            this.productRepository.Remove(Mapper.Map<Product>(product));
            this.unitOfWork.Save();
        }

        #endregion
    }
}