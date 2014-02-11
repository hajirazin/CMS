using Ramesoft.Cms.Common.Entity;
using Ramesoft.Cms.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.Services.Contract
{
    public interface IProductService : IDisposable
    {
        List<ProductModel> GetProducts { get; }

        ProductModel Find(Func<ProductModel, bool> predicate);

        void Add(ProductModel product);
        void Add(IEnumerable<ProductModel> products);

        void Remove(ProductModel product);
        IEnumerable<Company> Companies { get; }
    }
}
