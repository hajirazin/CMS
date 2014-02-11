using Ramesoft.Cms.Common.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.Models
{
    public class CategoryModel : ISelectable
    {
        string ISelectable.Text
        {
            get
            {
                return this.CategoryName;
            }
        }

        string ISelectable.Value
        {
            get
            {
                return this.CategoryId.ToString();
            }
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
