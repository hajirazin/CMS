// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationKeys.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   Defines the ConfigurationKeys type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Utility
{
    using System.Configuration;

    /// <summary>
    /// The configuration keys.
    /// </summary>
    public static class ConfigurationKeys
    {
        /// <summary>
        /// Gets the service address.
        /// </summary>
        public static string ServiceAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["APIAddress"];
            }
        }
    }
}
