namespace NetflexWatchList.Service.Services.Interface
{
    using NetflexWatchList.Shared.ExternalModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The IImdbService interface.
    /// </summary>
    public interface IImdbService
    {
        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The list of IMDbSearchResult.</returns>
        Task<IList<ImdbSearchResult>> GetShows(string title);

        /// <summary>
        /// Gets the show by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The IMDbShow.</returns>
        Task<ImdbShow> GetShowById(string id);

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The list of ImdbEpisode.</returns>
        Task<IList<ImdbEpisode>> GetEpisodes(string imdbId, int seasonNumber);

        /// <summary>
        /// Gets all shows.
        /// </summary>
        /// <returns>
        /// The list of IMDb tv series data.
        /// </returns>
        Task<IList<ImdbTvSeriesData>> GetAllShows();
    }
}
