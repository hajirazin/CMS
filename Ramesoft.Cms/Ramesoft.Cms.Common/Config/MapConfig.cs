// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The map config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Config
{
    using System.Linq;

    using AutoMapper;

    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;

    /// <summary>
    /// The map config.
    /// </summary>
    public static class MapConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create maps.
        /// </summary>
        public static void CreateMaps()
        {
            //Mapper.CreateMap<Product, ProductModel>()
            //    .ForMember(s => s.CatagoryName, m => m.MapFrom(d => d.SubCategory.Category.CategoryName))
            //    .ForMember(s => s.CompanyName, m => m.MapFrom(d => d.Company.CompanyName))
            //    .ForMember(s => s.SubCatagoryName, m => m.MapFrom(d => d.SubCategory.SubCategoryName));
            //Mapper.CreateMap<IQueryable<Product>, IQueryable<ProductModel>>();
        }

        #endregion
    }
}