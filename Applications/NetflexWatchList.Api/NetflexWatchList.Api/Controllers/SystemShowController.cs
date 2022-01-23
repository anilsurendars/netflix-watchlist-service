namespace NetflexWatchList.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NetflexWatchList.Service.Services.Interface;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The SystenShowController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Authorize]
    public class SystemShowController : BaseController
    {
        /// <summary>
        /// The imdb service.
        /// </summary>
        private readonly IImdbService _imdbService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemShowController"/> class.
        /// </summary>
        /// <param name="imdbService">The imdb service.</param>
        public SystemShowController(IImdbService imdbService)
        {
            _imdbService = imdbService;
        }

        /// <summary>
        /// Saves the show.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <returns>The actionresult.</returns>
        [HttpPost]
        [Route("api/v1/system/show/save/{imdbId}")]
        public async Task<IActionResult> SaveShow(string imdbId)
        {
            if (string.IsNullOrEmpty(imdbId)) { return BadRequest("Invalid parameters"); }

            var showResult = await _imdbService.SaveShowToSystem(imdbId, User.Identity.Name);

            return showResult <= 0 ? showResult == 0 ? BadRequest(new { message = "Show already exist." }) : BadRequest(new { message = "Something went wrong" }) 
                : new OkObjectResult(new { message = "Show added to the system." });
        }

        /// <summary>
        /// Gets the show from system by identifier.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/system/show/{showId}")]
        public async Task<IActionResult> GetShowFromSystemById(Guid showId)
        {
            if (showId == Guid.Empty) { return BadRequest("Invalid parameters"); }

            var showResult = await _imdbService.GetShowFromSystemById(showId);

            return showResult == null ? BadRequest(new { message = "Something went wrong" }) : new OkObjectResult(showResult);
        }

        /// <summary>
        /// Updates the episode as watched.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <param name="episodeId">The episode identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/system/show/{showId}/seasons/episode/update")]
        public async Task<IActionResult> UpdateEpisodeAsWatched(Guid showId, Guid episodeId, bool watchedStatus)
        {
            if (showId == Guid.Empty || episodeId == Guid.Empty) { BadRequest("Invalid parameter"); }

            var episode = await _imdbService.UpdateEpisodeStatus(showId, episodeId, watchedStatus, Guid.Parse(User.Identity.Name));

            return episode == null ? BadRequest(new { message = "Something went wrong" }) : new OkObjectResult(episode);
        }

        /// <summary>
        /// Gets all shows from system by user.
        /// </summary>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/system/shows")]
        public async Task<IActionResult> GetAllShowsFromSystemByUser()
        {
            var imdbShows = await _imdbService.GetAllShowsFromSystemByUserId(Guid.Parse(User.Identity.Name));

            return !imdbShows.Any() ? BadRequest(new { message = "Something went wrong" }) : new OkObjectResult(imdbShows);
        }
    }
}