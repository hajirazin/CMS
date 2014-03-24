// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="ramesoft">
//   ramesoft
// </copyright>
// <summary>
//   Defines the AccountController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Api.Controllers
{
    using System.Data.Entity;
    using System.Web.Http;

    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;
    using Ramesoft.Cms.Common.Models;

    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.userRepository = unitOfWork.GetStanderdRepository<User>();
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public LoginResponse Login(LoginModel model)
        {
            var user = this.userRepository.Find(profile => profile.Password == model.Password && profile.UserName == model.UserName);
            return new LoginResponse
                       {
                           UserId = user.UserId,
                           Company = user.Company.CompanyName,
                           CompanyId = user.CompanyId,
                           UserName = user.UserName,
                           Role = user.Role.RoleName,
                           PreferredLanguage = "en-US"
                       };
        }
    }
}
