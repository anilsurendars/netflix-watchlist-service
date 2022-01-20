namespace NetflexWatchList.Service.Repositories
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using NetflexWatchList.Data.Entities;
    using NetflexWatchList.Data.Repositories.Interface;
    using NetflexWatchList.Service.Repositories.Interface;
    using NetflexWatchList.Shared.ServiceModel;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The UserService implementaion.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Service.Repositories.Interface.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repo.
        /// </summary>
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<IUserService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepo">The user repo.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UserService(IUserRepository userRepo, IMapper mapper, ILogger<IUserService> logger)
        {
            _userRepo = userRepo;
            _mapper = mapper;   
            _logger = logger;
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="userServiceModel">The user service model..</param>
        /// <returns>
        /// The user service model.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<UserServiceModel> Create(UserServiceModel userServiceModel)
        {
            var userEntity = _mapper.Map<User>(userServiceModel);
            var responseEntity = await _userRepo.Create(userEntity);

            return _mapper.Map<UserServiceModel>(responseEntity);
        }

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// The user service model.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<UserServiceModel> GetByEmail(string email)
        {
            var responseEntity = await _userRepo.GetByEmail(email);

            if (responseEntity is null)
            {
                return null;
            }

            return _mapper.Map<UserServiceModel>(responseEntity);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user service model.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<UserServiceModel> GetById(Guid id)
        {
            var responseEntity = await _userRepo.GetById(id);

            if (responseEntity is null)
            {
                return null;
            }

            return _mapper.Map<UserServiceModel>(responseEntity);
        }
    }
}
