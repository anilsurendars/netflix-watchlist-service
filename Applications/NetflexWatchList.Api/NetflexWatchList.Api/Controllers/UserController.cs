namespace NetflexWatchList.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NetflexWatchList.Api.Models;
    using NetflexWatchList.Service.Repositories.Interface;
    using NetflexWatchList.Shared.ServiceModel;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The UserController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />

    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="logger">The logger.</param>
        public UserController(IMapper mapper, IUserService userService, ILogger<UserController> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The action result.</returns>
        [HttpGet]
        [Route("api/v1/user/get")]
        public async Task<IActionResult> GetUser(string email)
        {
            UserModel response = null;

            var serviceModel = await _userService.GetByEmail(email);
            if (serviceModel is not null)
            {
                response = _mapper.Map<UserModel>(serviceModel);
            }

            return new OkObjectResult(response);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The action result.</returns>
        [HttpGet]
        [Route("api/v1/user/get/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            UserModel response = null;

            var serviceModel = await _userService.GetById(id);
            if (serviceModel is not null)
            {
                response = _mapper.Map<UserModel>(serviceModel);
            }

            return response is null ? BadRequest(response) : new OkObjectResult(response);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="model">The user model.</param>
        /// <returns>The actionresult.</returns>
        [HttpPost]
        [Route("api/v1/user/create")]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceModel = _mapper.Map<UserServiceModel>(model);
            var user = await _userService.Create(serviceModel);

            return user is null ? NotFound("user already exist.") : new OkObjectResult(_mapper.Map<UserModel>(user));
        }
    }
}
