using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ramesoft.Cms.Common.Utility;

namespace Ramesoft.Cms.Common.Models
{
    public class ProductList : List<ProductModel>, IValidatableObject
    {
        public ProductList()
        {
        }

        public ProductList(IEnumerable<ProductModel> value)
            : base(value)
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new[] { ValidationResult.Success };
        }
    }
}
