namespace NetflexWatchList.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using NetflexWatchList.Api.Models;
    using NetflexWatchList.Service.Repositories.Interface;
    using NetflexWatchList.Shared.ServiceModel;
    using System.Threading.Tasks;

    /// <summary>
    /// The UserController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("api/v1/get")]
        public async Task<IActionResult> GetUser(string email)
        {
            UserModel response = null;

            var serviceModel = await _userService.GetByEmail(email);
            if(serviceModel is not null)
            {
                response = _mapper.Map<UserModel>(serviceModel);
            }

            return new OkObjectResult(response);
        }

    }
}
