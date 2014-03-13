// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductsController.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The products controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Ramesoft.Cms.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;
    using Ramesoft.Cms.Common.Services.Contract;
    using Ramesoft.Cms.Utility;

    /// <summary>
    ///     The products controller.
    /// </summary>
    [Authorize]
    public class ProductsController : Controller
    {
        #region Fields

        /// <summary>
        ///     The data context.
        /// </summary>
        private readonly EntityContext dataContext = new EntityContext();

        /// <summary>
        ///     The product service.
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        ///     The disposed.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">
        /// The product service.
        /// </param>
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Create()
        {
            this.ViewBag.CompanyId = new SelectList(this.productService.Companies, "CompanyId", "CompanyName");
            this.ViewBag.SubCategoryId = new SelectList(this.dataContext.Categories.Where(c => c.ParentCategory != null), "CategoryID", "CategoryName");
            this.ViewBag.CatagoryId =
                new HashSet<Category>(this.dataContext.Categories.Where(c => c.ParentCategory == null)).Select(
                    c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString(CultureInfo.InvariantCulture) });
            var products = new ProductList(this.productService.GetProducts);
            return this.View(products);
        }

        // POST: /Products/Create

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductList product)
        {
            if (product.IsDuplicate(i => i.ProductName))
            {
                this.ModelState.AddModelError(string.Empty, "Duplicate products");
            }

            if (this.ModelState.IsValid)
            {
                this.productService.Add(product.Where(i => i.ProductId == 0));

                this.dataContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.CompanyId = new SelectList(this.dataContext.Companies, "CompanyId", "CompanyName");
            this.ViewBag.SubCategoryId = new SelectList(this.dataContext.Categories, "SubCategoryId", "SubCategoryName");
            this.ViewBag.CatagoryId =
                new HashSet<Category>(this.dataContext.Categories).Select(
                    c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString(CultureInfo.InvariantCulture) });

            return this.View(product);
        }

        // GET: /Products/Delete/5

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Delete(int id = 0)
        {
            var product = Mapper.Map<Product>(this.productService.Find(i => i.ProductId == id));
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        // POST: /Products/Delete/5

        /// <summary>
        /// The delete confirmed.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModel product = this.productService.Find(i => i.ProductId == id);
            this.productService.Remove(product);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The details.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Details(int id = 0)
        {
            var product = Mapper.Map<Product>(this.productService.Find(i => i.ProductId == id));
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Edit(int id = 0)
        {
            var product = Mapper.Map<Product>(this.productService.Find(i => i.ProductId == id));
            if (product == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.CompanyId = new SelectList(
                this.productService.Companies, 
                "CompanyId", 
                "CompanyName", 
                product.CategoryID);
            this.ViewBag.SubCategoryId = new SelectList(
                this.dataContext.Categories, 
                "SubCategoryId", 
                "SubCategoryName", 
                product.CategoryID);
            return this.View(product);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.dataContext.Entry(product).State = EntityState.Modified;
                this.dataContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.CompanyId = new SelectList(
                this.dataContext.Companies, 
                "CompanyId", 
                "CompanyName", 
                product.CategoryID);
            this.ViewBag.SubCategoryId = new SelectList(
                this.dataContext.Categories, 
                "SubCategoryId", 
                "SubCategoryName", 
                product.CategoryID);
            return this.View(product);
        }

        /// <summary>
        ///     The index.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Index()
        {
            return this.View(this.productService.GetProducts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.productService.Dispose();
            this.dataContext.Dispose();
            base.Dispose(disposing);
            this.disposed = true;
        }

        #endregion
    }
}