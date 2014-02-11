
using Ramesoft.Cms.Common.Config;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ramesoft.Cms.Models
{
    public class MyDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            try
            {
                return UnityConfig.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return UnityConfig.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}