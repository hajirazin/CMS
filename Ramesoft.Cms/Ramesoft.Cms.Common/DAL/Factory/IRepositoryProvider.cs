using Ramesoft.Cms.Common.DAL.Factory;
using Ramesoft.Cms.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.DAL.Factory
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>() where T : class;
        IEntityContext DataContext { get; set; }
        IRepository<T> GetStanderdRepository<T>() where T : class;
    }
}
