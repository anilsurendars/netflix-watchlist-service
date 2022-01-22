namespace NetflexWatchList.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    public class DashboardController : BaseController
    {
    }
}
