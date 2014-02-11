using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using Ramesoft.Cms.Models;
using Ramesoft.Cms.Common.Logging;
using Ramesoft.Cms.Common.Entity;
using System.Text;
using System.Web.Security;
using Ramesoft.Cms.Common.DAL.Enums;
using Ramesoft.Cms.Common.Config;

namespace Ramesoft.Cms.Filters
{
    using System.Data.Entity.Core.EntityClient;

    using UserProfile = Ramesoft.Cms.Models.UserProfile;

    /// <summary>
    /// The initialize simple membership attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The _initializer.
        /// </summary>
        private static SimpleMembershipInitializer initializer;

        /// <summary>
        /// The initializer lock.
        /// </summary>
        private static object initializerLock = new object();

        /// <summary>
        /// The _is initialized.
        /// </summary>
        private static bool isInitialized;

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Error")
            {
                LazyInitializer.EnsureInitialized(ref initializer, ref isInitialized, ref initializerLock);
                Logger.LogInfo("Action:" + filterContext.ActionDescriptor.ActionName + " of Controller:" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + " is called.");
            }
        }

        /// <summary>
        /// The simple membership initializer.
        /// </summary>
        private class SimpleMembershipInitializer
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SimpleMembershipInitializer"/> class.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// Throws Exception
            /// </exception>
            public SimpleMembershipInitializer()
            {
                try
                {
                    if (!Database.Exists("DefaultConnection"))
                    {
                        Database.SetInitializer(new CreateDatabaseIfNotExists<EntityContext>());
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", true);
                    
                    if (!WebSecurity.UserExists("razinmemon"))
                    {
                        WebSecurity.CreateUserAndAccount("razinmemon", "ABab@123");
                        if (!Roles.RoleExists(UserTypes.SuperAdmin.ToString()))
                        {
                            Roles.CreateRole(UserTypes.SuperAdmin.ToString());
                        }

                        Roles.AddUserToRole("razinmemon", UserTypes.SuperAdmin.ToString());
                    }
                    else if (!Roles.IsUserInRole("razinmemon", UserTypes.SuperAdmin.ToString()))
                    {
                        if (!Roles.RoleExists(UserTypes.SuperAdmin.ToString()))
                        {
                            Roles.CreateRole(UserTypes.SuperAdmin.ToString());
                        }

                        Roles.AddUserToRole("razinmemon", UserTypes.SuperAdmin.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
