// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   Defines the LoginModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Ramesoft.Cms.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The login model.
    /// </summary>
    public class LoginModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remember me.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }
}