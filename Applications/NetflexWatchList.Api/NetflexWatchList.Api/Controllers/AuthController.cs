namespace NetflexWatchList.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NetflexWatchList.Api.Models;
    using NetflexWatchList.Api.Security;
    using NetflexWatchList.Service.Repositories.Interface;
    using NetflexWatchList.Shared.ServiceModel;
    using System.Threading.Tasks;

    /// <summary>
    /// The Auth Controller.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Api.Controllers.BaseController" />
    [ApiController]
    public class AuthController : BaseController
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The JWT service.
        /// </summary>
        private readonly IJwtAuthService _jwtService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="jwtService">The JWT service.</param>
        public AuthController(IUserService userService, IMapper mapper, ILogger<AuthController> logger, IJwtAuthService jwtService)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The actionresult.</returns>
        [Route("api/v1/auth/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceModel = _mapper.Map<UserServiceModel>(model);
            var user = await _userService.Create(serviceModel);

            return user is null ? Problem("User already exist.") : new OkObjectResult(new
            {
                message = "success"
            });
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The actionresult.</returns>
        [Route("api/v1/auth/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetByEmail(model.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.GenerateToken(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>The actionResult.</returns>
        [Route("api/v1/auth/logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwt");

            return await Task.FromResult(new OkObjectResult(new
            {
                message = "success"
            }));
        }
    }
}
