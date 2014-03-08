// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The unity config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Config
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    /// <summary>
    /// The unity config.
    /// </summary>
    public static class UnityConfig
    {
        #region Static Fields

        /// <summary>
        /// The container.
        /// </summary>
        private static IWindsorContainer container;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the container.
        /// </summary>
        public static IWindsorContainer Container
        {
            get
            {
                LazyInitializer.EnsureInitialized(ref container, Configure);
                return container;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>(IDictionary arguments)
        {
            LazyInitializer.EnsureInitialized(ref container, Configure);
            return container.Resolve<T>(arguments);
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>()
        {
            LazyInitializer.EnsureInitialized(ref container, Configure);

            return container.Resolve<T>();
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object Resolve(Type type)
        {
            LazyInitializer.EnsureInitialized(ref container, Configure);

            return container.Resolve(type);
        }

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<object> ResolveAll(Type type)
        {
            LazyInitializer.EnsureInitialized(ref container, Configure);
            return container.ResolveAll(type).OfType<object>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The configure.
        /// </summary>
        /// <returns>
        /// The <see cref="IWindsorContainer"/>.
        /// </returns>
        private static IWindsorContainer Configure()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly().Pick().WithServiceDefaultInterfaces().LifestyleTransient());
            return container;
        }

        #endregion
    }
}