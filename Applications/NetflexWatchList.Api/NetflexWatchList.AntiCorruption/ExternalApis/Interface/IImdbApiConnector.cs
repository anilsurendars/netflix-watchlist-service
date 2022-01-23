using NetflexWatchList.Shared.ExternalModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetflexWatchList.AntiCorruption.ExternalApis.Interface
{
    /// <summary>
    /// The IMDbApi Connector interface.
    /// </summary>
    public interface IImdbApiConnector
    {
        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The list of IMDbSearchResult.</returns>
        Task<IList<ImdbSearchResult>> SearchShowByTitle(string title);

        /// <summary>
        /// Gets the show by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The IMDbShow.</returns>
        Task<ImdbShow> GetShowByIMDbId(string id);

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The list of ImdbEpisode.</returns>
        Task<IList<ImdbEpisode>> GetEpisodesByIMDbIdAndSeasonNumber(string imdbId, int seasonNumber);

        /// <summary>
        /// Gets all shows.
        /// </summary>
        /// <returns>The list of IMDb tv series data.</returns>
        Task<IList<ImdbTvSeriesData>> GetAllShows();
    }
}
