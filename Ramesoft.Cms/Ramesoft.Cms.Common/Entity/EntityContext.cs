// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityContext.cs" company="">
//   
// </copyright>
// <summary>
//   The entity context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Entity
{
    /// <summary>
    /// The entity context.
    /// </summary>
    public class EntityContext : RamesoftEntities, IEntityContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        public EntityContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}