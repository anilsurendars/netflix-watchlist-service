namespace NetflexWatchList.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using NetflexWatchList.Service.Services.Interface;
    using NetflexWatchList.Shared;
    using NetflexWatchList.Shared.ExternalModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The Dashboard.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Api.Controllers.BaseController" />
    [ApiController]
    [Authorize]
    public class DashboardController : BaseController
    {
        /// <summary>
        /// The imdb service.
        /// </summary>
        private readonly IImdbService _imdbService;

        /// <summary>
        /// The cache.
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        /// <param name="imdbService">The imdb service.</param>
        /// <param name="cache">The cache.</param>
        public DashboardController(IImdbService imdbService, IMemoryCache cache)
        {
            _imdbService = imdbService;
            _cache = cache;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The action result.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/show/getall")]
        public async Task<IActionResult> GetAllShows()
        {
            if (!_cache.TryGetValue(AppConstants.GetAllShows, out IList<ImdbTvSeriesData> tvSerieslist))
            {
                tvSerieslist = await _imdbService.GetAllIMDbShows();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                _cache.Set(AppConstants.GetAllShows, tvSerieslist, cacheEntryOptions);
            }

            return new OkObjectResult(tvSerieslist);
        }

        /// <summary>
        /// Searches the show.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/show/search")]
        public async Task<IActionResult> SearchShowByTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) { return BadRequest("Invalid parameter."); }

            var showSearchResult = await _imdbService.SearchShowByTitle(title);

            return !showSearchResult.Any() ? BadRequest(new { message = "No tv show available for your search title." }) : new OkObjectResult(showSearchResult);
        }

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/show/{imdbId}")]
        public async Task<IActionResult> GetShowByIMDbId([FromRoute] string imdbId)
        {
            if (string.IsNullOrEmpty(imdbId)) { return BadRequest("Invalid parameter."); }

            var showResult = await _imdbService.GetShowByIMDbId(imdbId);

            return showResult == null ? BadRequest(new { message = "No tv show available for your imdbId. Please check the imdbId" }) : new OkObjectResult(showResult);
        }

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The actionresult.</returns>
        [HttpGet]
        [Route("api/v1/dashboard/show/{imdbId}/seasons/{seasonNumber}")]
        public async Task<IActionResult> GetEpisodesByIMDbIdAndSeasonNumber([FromRoute] string imdbId, [FromRoute] string seasonNumber)
        {
            if (string.IsNullOrEmpty(imdbId) || string.IsNullOrEmpty(seasonNumber)) { return BadRequest("Invalid parameter."); }

            var imdbSeasons = await _imdbService.GetEpisodesByIMDbIdAndSeasonNumber(imdbId, int.Parse(seasonNumber));

            return !imdbSeasons.Any() ? BadRequest(new { message = "No episodes available for your imdbId and season." }) : new OkObjectResult(imdbSeasons);
        }
    }
}
