// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountModels.cs" company="">
//   
// </copyright>
// <summary>
//   The users context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Web.Mvc;

    /// <summary>
    /// The users context.
    /// </summary>
    public class UsersContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersContext"/> class.
        /// </summary>
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the user profiles.
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }

        #endregion
    }

    /// <summary>
    /// The user profile.
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The register external login model.
    /// </summary>
    public class RegisterExternalLoginModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the external login data.
        /// </summary>
        public string ExternalLoginData { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The local password model.
    /// </summary>
    public class LocalPasswordModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion
    }

    /// <summary>
    /// The register model.
    /// </summary>
    public class RegisterModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The external login.
    /// </summary>
    public class ExternalLogin
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the provider display name.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the provider user id.
        /// </summary>
        public string ProviderUserId { get; set; }

        #endregion
    }
}