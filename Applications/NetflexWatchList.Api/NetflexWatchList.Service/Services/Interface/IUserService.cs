namespace NetflexWatchList.Service.Repositories.Interface
{
    using NetflexWatchList.Shared.ServiceModel;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The User service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="userServiceModel">The user service model.</param>
        /// <returns>The user service model.</returns>
        Task<UserServiceModel> Create(UserServiceModel userServiceModel);

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The user service model.</returns>
        Task<UserServiceModel> GetByEmail(string email);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user service model.</returns>
        Task<UserServiceModel> GetById(Guid id);
    }
}
