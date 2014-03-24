// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginResponse.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The login response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Models
{
    /// <summary>
    /// The login response.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the preferred language.
        /// </summary>
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }
    }
}
