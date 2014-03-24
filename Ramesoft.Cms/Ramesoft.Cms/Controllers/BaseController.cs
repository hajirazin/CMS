// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Controllers
{
    using System;
    using System.Net.Http;
    using System.Web.Mvc;

    using Ramesoft.Cms.Common.Utility;

    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        protected BaseController()
        {
            this.Client = new HttpClient();
            this.Client.BaseAddress = new Uri(ConfigurationKeys.ServiceAddress);
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        protected HttpClient Client { get; private set; }
    }
}
