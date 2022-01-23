namespace NetflexWatchList.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NetflexWatchList.Service.Services.Interface;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IImdbService _imdbService;

        public DashboardController(IImdbService imdbService)
        {
            _imdbService = imdbService;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The action result.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/shows/getall")]
        public async Task<IActionResult> GetAllShows()
        {
            var tvSerieslist = await _imdbService.GetAllShows();

            return !tvSerieslist.Any() ? BadRequest(new { message = "Not available." }) : new OkObjectResult(tvSerieslist);
        }

        /// <summary>
        /// Searches the show.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/shows/search")]
        public async Task<IActionResult> SearchShow(string title)
        {
            if (string.IsNullOrEmpty(title)) { return BadRequest("Invalid parameter."); }

            var showSearchResult = await _imdbService.GetShows(title);

            return !showSearchResult.Any() ? BadRequest(new { message = "No tv show available for your search title." }) : new OkObjectResult(showSearchResult);
        }

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/shows/{imdbId}")]
        public async Task<IActionResult> GetShow([FromRoute] string imdbId)
        {
            if (string.IsNullOrEmpty(imdbId)) { return BadRequest("Invalid parameter."); }

            var showResult = await _imdbService.GetShowById(imdbId);

            return showResult == null ? BadRequest(new { message = "No tv show available for your imdbId. Please check the imdbId" }) : new OkObjectResult(showResult);
        }


        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/shows/{imdbId}/seasons/{seasonNumber}")]
        public async Task<IActionResult> GetEpisodes([FromRoute] string imdbId, [FromRoute] string seasonNumber)
        {
            if (string.IsNullOrEmpty(imdbId) || string.IsNullOrEmpty(seasonNumber)) { return BadRequest("Invalid parameter."); }

            var imdbSeasons = await _imdbService.GetEpisodes(imdbId, int.Parse(seasonNumber));

            return !imdbSeasons.Any() ? BadRequest(new { message = "No episodes available for your imdbId and season." }) : new OkObjectResult(imdbSeasons);
        }
    }
}
