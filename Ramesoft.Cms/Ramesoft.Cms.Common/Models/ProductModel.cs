using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Ramesoft.Cms.Common.Models
{
    [Serializable]
    public class ProductModel
    {
        private string productName;

        private string catagoryName;

        private string subCatagoryName;

        private string companyName;

        public int ProductId { get; set; }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                this.productName = value != null ? value.Trim() : string.Empty;
            }
        }

        public string CatagoryName
        {
            get
            {
                return this.catagoryName;
            }

            set
            {
                this.catagoryName = value != null ? value.Trim() : string.Empty;
            }
        }

        public string SubCatagoryName
        {
            get
            {
                return this.subCatagoryName;
            }

            set
            {
                this.subCatagoryName = value != null ? value.Trim() : string.Empty;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                this.companyName = value != null ? value.Trim() : string.Empty;
            }
        }

        public int CompanyId { get; set; }

        public int SubCatagoryId { get; set; }

        public int CatagoryId { get; set; }
    }
}
