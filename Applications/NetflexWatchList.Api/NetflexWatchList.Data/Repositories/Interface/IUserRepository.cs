namespace NetflexWatchList.Data.Repositories.Interface
{
    using NetflexWatchList.Data.Entities;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The UserRepository interface.
    /// </summary>
    public interface IUserRepository
    {

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>The task user.</returns>
        Task<User> Create(User userEntity);

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The task user.</returns>
        Task<User> GetByEmail(string email);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The task user.</returns>
        Task<User> GetById(Guid id);
    }
}
