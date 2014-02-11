using Ramesoft.Cms.Common.DAL.Factory;
using Ramesoft.Cms.Common.DAL.Repository;
using Ramesoft.Cms.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryProvider repositoryProvider;

        public UnitOfWork(IRepositoryProvider repositoryProvider, IEntityContext dataContext)
        {
            this.repositoryProvider = repositoryProvider;
            this.DataContext = dataContext;
            this.repositoryProvider.DataContext = dataContext;
        }

        public T GetRepository<T>() where T : class
        {
            return this.repositoryProvider.GetRepository<T>();
        }

        public IEntityContext DataContext { get; set; }

        public IRepository<T> GetStanderdRepository<T>() where T : class
        {
            return this.repositoryProvider.GetStanderdRepository<T>();
        }

        public void Save()
        {
            this.DataContext.SaveChanges();
        }
    }
}
