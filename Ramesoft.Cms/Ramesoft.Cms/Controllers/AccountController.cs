// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="rs">
//   rs
// </copyright>
// <summary>
//   The account controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Mvc;

    using Microsoft.Web.WebPages.OAuth;

    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;
    using Ramesoft.Cms.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The account controller.
    /// </summary>
    [Authorize]
    public class AccountController : BaseController
    {
        #region Enums

        /// <summary>
        /// The manage message id.
        /// </summary>
        public enum ManageMessageId
        {
            /// <summary>
            /// The change password success.
            /// </summary>
            ChangePasswordSuccess,

            /// <summary>
            /// The set password success.
            /// </summary>
            SetPasswordSuccess,

            /// <summary>
            /// The remove login success.
            /// </summary>
            RemoveLoginSuccess,
        }

        #endregion

        #region Public Methods and Operators

        /////// <summary>
        /////// The disassociate.
        /////// </summary>
        /////// <param name="provider">
        /////// The provider.
        /////// </param>
        /////// <param name="providerUserId">
        /////// The provider user id.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Disassociate(string provider, string providerUserId)
        ////{
        ////    string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
        ////    ManageMessageId? message;

        ////    // Only disassociate the account if the currently logged in user is the owner
        ////    if (ownerAccount != this.User.Identity.Name)
        ////    {
        ////        return this.RedirectToAction("Manage", new { Message = (ManageMessageId?)null });
        ////    }

        ////    // Use a transaction to prevent the user from deleting their last login credential
        ////    using (
        ////        var scope = new TransactionScope(
        ////            TransactionScopeOption.Required,
        ////            new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
        ////    {
        ////        var hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
        ////        if (!hasLocalAccount && OAuthWebSecurity.GetAccountsFromUserName(this.User.Identity.Name).Count <= 1)
        ////        {
        ////            return this.RedirectToAction("Manage", new { Message = (ManageMessageId?)null });
        ////        }

        ////        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
        ////        scope.Complete();
        ////        message = ManageMessageId.RemoveLoginSuccess;
        ////    }

        ////    return this.RedirectToAction("Manage", new { Message = message });
        ////}

        /////// <summary>
        /////// The external login.
        /////// </summary>
        /////// <param name="provider">
        /////// The provider.
        /////// </param>
        /////// <param name="returnUrl">
        /////// The return url.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult ExternalLogin(string provider, string returnUrl)
        ////{
        ////    return new ExternalLoginResult(
        ////        provider,
        ////        this.Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        ////}

        /////// <summary>
        /////// The external login callback.
        /////// </summary>
        /////// <param name="returnUrl">
        /////// The return url.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[AllowAnonymous]
        ////public ActionResult ExternalLoginCallback(string returnUrl)
        ////{
        ////    var result =
        ////        OAuthWebSecurity.VerifyAuthentication(
        ////            this.Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        ////    if (!result.IsSuccessful)
        ////    {
        ////        return this.RedirectToAction("ExternalLoginFailure");
        ////    }

        ////    if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, false))
        ////    {
        ////        return this.RedirectToLocal(returnUrl);
        ////    }

        ////    if (this.User.Identity.IsAuthenticated)
        ////    {
        ////        // If the current user is logged in add the new account
        ////        OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, this.User.Identity.Name);
        ////        return this.RedirectToLocal(returnUrl);
        ////    }

        ////    // User is new, ask for their desired membership name
        ////    string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
        ////    this.ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
        ////    this.ViewBag.ReturnUrl = returnUrl;
        ////    return this.View(
        ////        "ExternalLoginConfirmation",
        ////        new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
        ////}

        /////// <summary>
        /////// The external login confirmation.
        /////// </summary>
        /////// <param name="model">
        /////// The model.
        /////// </param>
        /////// <param name="returnUrl">
        /////// The return url.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        ////{
        ////    string provider;
        ////    string providerUserId;

        ////    if (this.User.Identity.IsAuthenticated
        ////        || !OAuthWebSecurity.TryDeserializeProviderUserId(
        ////            model.ExternalLoginData,
        ////            out provider,
        ////            out providerUserId))
        ////    {
        ////        return this.RedirectToAction("Manage");
        ////    }

        ////    if (this.ModelState.IsValid)
        ////    {
        ////        // Insert a new user into the database
        ////        using (var db = new UsersContext())
        ////        {
        ////            var user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

        ////            // Check if user already exists
        ////            if (user == null)
        ////            {
        ////                // Insert name into the profile table
        ////                db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
        ////                db.SaveChanges();

        ////                OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
        ////                OAuthWebSecurity.Login(provider, providerUserId, false);

        ////                return this.RedirectToLocal(returnUrl);
        ////            }

        ////            this.ModelState.AddModelError(
        ////                "UserName",
        ////                "User name already exists. Please enter a different user name.");
        ////        }
        ////    }

        ////    this.ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
        ////    this.ViewBag.ReturnUrl = returnUrl;
        ////    return this.View(model);
        ////}

        ////// GET: /Account/ExternalLoginFailure

        /////// <summary>
        /////// The external login failure.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[AllowAnonymous]
        ////public ActionResult ExternalLoginFailure()
        ////{
        ////    return this.View();
        ////}

        /////// <summary>
        /////// The external logins list.
        /////// </summary>
        /////// <param name="returnUrl">
        /////// The return url.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[AllowAnonymous]
        ////[ChildActionOnly]
        ////public ActionResult ExternalLoginsList(string returnUrl)
        ////{
        ////    this.ViewBag.ReturnUrl = returnUrl;
        ////    return this.PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        ////}

        /// <summary>
        /// The log off.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return this.RedirectToAction("Index", "Products");
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            this.ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        // POST: /Account/Login

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                var response = this.Client.PostAsJsonAsync("/api/account/Login", model).Result;
                var user = response.Content.ReadAsAsync<LoginResponse>().Result;
                this.Session["UserDetail"] = user;
                return this.RedirectToAction("Index", "Products");
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            return this.View(model);
        }

        /////// <summary>
        /////// The manage.
        /////// </summary>
        /////// <param name="message">
        /////// The message.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////public ActionResult Manage(ManageMessageId? message)
        ////{
        ////    this.ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess
        ////                                     ? "Your password has been changed."
        ////                                     : message == ManageMessageId.SetPasswordSuccess
        ////                                           ? "Your password has been set."
        ////                                           : message == ManageMessageId.RemoveLoginSuccess
        ////                                                 ? "The external login was removed."
        ////                                                 : string.Empty;
        ////    this.ViewBag.HasLocalPassword =
        ////        OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
        ////    this.ViewBag.ReturnUrl = this.Url.Action("Manage");
        ////    return this.View();
        ////}

        // POST: /Account/Manage

        /////// <summary>
        /////// The manage.
        /////// </summary>
        /////// <param name="model">
        /////// The model.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Manage(LocalPasswordModel model)
        ////{
        ////    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(this.User.Identity.Name));
        ////    this.ViewBag.HasLocalPassword = hasLocalAccount;
        ////    this.ViewBag.ReturnUrl = this.Url.Action("Manage");
        ////    if (hasLocalAccount)
        ////    {
        ////        if (!this.ModelState.IsValid)
        ////        {
        ////            return this.View(model);
        ////        }

        ////        // ChangePassword will throw an exception rather than return false in certain failure scenarios.
        ////        bool changePasswordSucceeded;
        ////        try
        ////        {
        ////            changePasswordSucceeded = WebSecurity.ChangePassword(
        ////                this.User.Identity.Name,
        ////                model.OldPassword,
        ////                model.NewPassword);
        ////        }
        ////        catch (Exception)
        ////        {
        ////            changePasswordSucceeded = false;
        ////        }

        ////        if (changePasswordSucceeded)
        ////        {
        ////            return this.RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        ////        }

        ////        this.ModelState.AddModelError(
        ////            string.Empty,
        ////            "The current password is incorrect or the new password is invalid.");
        ////    }
        ////    else
        ////    {
        ////        // User does not have a local password so remove any validation errors caused by a missing
        ////        // OldPassword field
        ////        var state = this.ModelState["OldPassword"];
        ////        if (state != null)
        ////        {
        ////            state.Errors.Clear();
        ////        }

        ////        if (!this.ModelState.IsValid)
        ////        {
        ////            return this.View(model);
        ////        }

        ////        try
        ////        {
        ////            WebSecurity.CreateAccount(this.User.Identity.Name, model.NewPassword);
        ////            return this.RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        ////        }
        ////        catch (Exception)
        ////        {
        ////            this.ModelState.AddModelError(
        ////                string.Empty,
        ////                string.Format(
        ////                    "Unable to create local account. An account with the name \"{0}\" may already exist.",
        ////                    this.User.Identity.Name));
        ////        }
        ////    }

        ////    // If we got this far, something failed, redisplay form
        ////    return this.View(model);
        ////}

        /////// <summary>
        /////// The register.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[AllowAnonymous]
        ////public ActionResult Register()
        ////{
        ////    return this.View();
        ////}

        ////// POST: /Account/Register

        /////// <summary>
        /////// The register.
        /////// </summary>
        /////// <param name="model">
        /////// The model.
        /////// </param>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Register(RegisterModel model)
        ////{
        ////    if (!this.ModelState.IsValid)
        ////    {
        ////        return this.View(model);
        ////    }

        ////    // Attempt to register the user
        ////    try
        ////    {
        ////        WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
        ////        if (!Roles.RoleExists(UserTypes.User.ToString()))
        ////        {
        ////            Roles.CreateRole(UserTypes.User.ToString());
        ////        }

        ////        Roles.AddUserToRole(model.UserName, UserTypes.User.ToString());
        ////        WebSecurity.Login(model.UserName, model.Password);
        ////        return this.RedirectToAction("Index", "Home");
        ////    }
        ////    catch (MembershipCreateUserException e)
        ////    {
        ////        this.ModelState.AddModelError(string.Empty, ErrorCodeToString(e.StatusCode));
        ////    }

        ////    // If we got this far, something failed, redisplay form
        ////    return this.View(model);
        ////}

        /////// <summary>
        /////// The remove external logins.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="ActionResult"/>.
        /////// </returns>
        ////[ChildActionOnly]
        ////public ActionResult RemoveExternalLogins()
        ////{
        ////    ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(this.User.Identity.Name);
        ////    var externalLogins = (from account in accounts
        ////                          let clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider)
        ////                          select
        ////                              new ExternalLogin
        ////                                  {
        ////                                      Provider = account.Provider,
        ////                                      ProviderDisplayName = clientData.DisplayName,
        ////                                      ProviderUserId = account.ProviderUserId,
        ////                                  }).ToList();

        ////    this.ViewBag.ShowRemoveButton = externalLogins.Count > 1
        ////                                    || OAuthWebSecurity.HasLocalAccount(
        ////                                        WebSecurity.GetUserId(this.User.Identity.Name));
        ////    return this.PartialView("_RemoveExternalLoginsPartial", externalLogins);
        ////}

        #endregion

        #region Methods

        /////// <summary>
        /////// The error code to string.
        /////// </summary>
        /////// <param name="createStatus">
        /////// The create status.
        /////// </param>
        /////// <returns>
        /////// The <see cref="string"/>.
        /////// </returns>
        ////private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        ////{
        ////    switch (createStatus)
        ////    {
        ////        case MembershipCreateStatus.DuplicateUserName:
        ////            return "User name already exists. Please enter a different user name.";

        ////        case MembershipCreateStatus.DuplicateEmail:
        ////            return
        ////                "A user name for that e-mail address already exists. Please enter a different e-mail address.";

        ////        case MembershipCreateStatus.InvalidPassword:
        ////            return "The password provided is invalid. Please enter a valid password value.";

        ////        case MembershipCreateStatus.InvalidEmail:
        ////            return "The e-mail address provided is invalid. Please check the value and try again.";

        ////        case MembershipCreateStatus.InvalidAnswer:
        ////            return "The password retrieval answer provided is invalid. Please check the value and try again.";

        ////        case MembershipCreateStatus.InvalidQuestion:
        ////            return "The password retrieval question provided is invalid. Please check the value and try again.";

        ////        case MembershipCreateStatus.InvalidUserName:
        ////            return "The user name provided is invalid. Please check the value and try again.";

        ////        case MembershipCreateStatus.ProviderError:
        ////            return
        ////                "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        ////        case MembershipCreateStatus.UserRejected:
        ////            return
        ////                "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        ////        default:
        ////            return
        ////                "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        ////    }
        ////}

        /// <summary>
        /// The redirect to local.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Products");
        }

        #endregion

        /// <summary>
        /// The external login result.
        /// </summary>
        internal class ExternalLoginResult : ActionResult
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ExternalLoginResult"/> class.
            /// </summary>
            /// <param name="provider">
            /// The provider.
            /// </param>
            /// <param name="returnUrl">
            /// The return url.
            /// </param>
            public ExternalLoginResult(string provider, string returnUrl)
            {
                this.Provider = provider;
                this.ReturnUrl = returnUrl;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the provider.
            /// </summary>
            public string Provider { get; private set; }

            /// <summary>
            /// Gets the return url.
            /// </summary>
            public string ReturnUrl { get; private set; }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The execute result.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(this.Provider, this.ReturnUrl);
            }

            #endregion
        }
    }
}