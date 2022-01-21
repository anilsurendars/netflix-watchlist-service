namespace NetflexWatchList.Data.Repositories
{
    using Microsoft.Extensions.Logging;
    using NetflexWatchList.Data.Context;
    using NetflexWatchList.Data.Entities;
    using NetflexWatchList.Data.Repositories.Interface;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The user repository.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Data.Repositories.Interface.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly INetflixWatchlistDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<IUserRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public UserRepository(INetflixWatchlistDbContext context, ILogger<IUserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>
        /// The task user.
        /// </returns>
        public async Task<User> Create(User userEntity)
        {
            try
            {
                var existingUser = await GetByEmail(userEntity.Email);
                if (existingUser != null) { return null; }

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return userEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// The task user.
        /// </returns>
        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await Task.FromResult(_context.Users.FirstOrDefault(x => x.Email == email));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The task user.
        /// </returns>
        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await Task.FromResult(_context.Users.SingleOrDefault(x => x.Id == id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
