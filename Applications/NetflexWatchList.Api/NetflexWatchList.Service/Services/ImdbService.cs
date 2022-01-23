namespace NetflexWatchList.Service.Services
{
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;
    using NetflexWatchList.Service.Services.Interface;
    using NetflexWatchList.Shared.ExternalModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The ImdbService implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Service.Services.Interface.IImdbService" />
    public class ImdbService : IImdbService
    {
        /// <summary>
        /// The API connector.
        /// </summary>
        public readonly IImdbApiConnector _apiConnector;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImdbService"/> class.
        /// </summary>
        /// <param name="imdbApiConnector">The imdb API connector.</param>
        public ImdbService(IImdbApiConnector imdbApiConnector)
        {
            _apiConnector = imdbApiConnector;
        }

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>
        /// The list of IMDbSearchResult.
        /// </returns>
        public async Task<IList<ImdbSearchResult>> GetShows(string title)
        {
            return await _apiConnector.GetShows(title);
        }

        /// <summary>
        /// Gets the show by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The IMDbShow.
        /// </returns>
        public async Task<ImdbShow> GetShowById(string id)
        {
            return await _apiConnector.GetShowById(id);
        }

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>
        /// The list of ImdbEpisode.
        /// </returns>
        public async Task<IList<ImdbEpisode>> GetEpisodes(string imdbId, int seasonNumber)
        {
            return await _apiConnector.GetEpisodes(imdbId, seasonNumber);
        }

        /// <summary>
        /// Gets all shows.
        /// </summary>
        /// <returns>
        /// The list of IMDb tv series data.
        /// </returns>
        public async Task<IList<ImdbTvSeriesData>> GetAllShows()
        {
            return await _apiConnector.GetAllShows();
        }
    }
}
