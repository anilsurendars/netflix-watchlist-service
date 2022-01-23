namespace NetflexWatchList.Service.Services.Interface
{
    using NetflexWatchList.Shared.ExternalModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The IImdbService interface.
    /// </summary>
    public interface IImdbService
    {
        /// <summary>
        /// Searches the show by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The list of IMDbSearchResult.</returns>
        Task<IList<ImdbSearchResult>> SearchShowByTitle(string title);

        /// <summary>
        /// Gets the show by im database identifier.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <returns>The ImdbShow.</returns>
        Task<ImdbShow> GetShowByIMDbId(string imdbId);

        /// <summary>
        /// Gets the episodes by imdb identifier and season number.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The list of ImdbEpisode.</returns>
        Task<IList<ImdbEpisode>> GetEpisodesByIMDbIdAndSeasonNumber(string imdbId, int seasonNumber);

        /// <summary>
        /// Gets all top 250 IMDb shows.
        /// </summary>
        /// <returns>The list of IMDb tv series data.</returns>
        Task<IList<ImdbTvSeriesData>> GetAllIMDbShows();

        /// <summary>
        /// Saves the show to system.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task int.</returns>
        Task<int> SaveShowToSystem(string imdbId, string userId);

        /// <summary>
        /// Gets the show from system by identifier.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <returns>The task ImdbShow.</returns>
        Task<ImdbShow> GetShowFromSystemById(Guid showId);

        /// <summary>
        /// Gets all shows from system by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task list of ImdbShow.</returns>
        Task<IList<ImdbShow>> GetAllShowsFromSystemByUserId(Guid userId);

        /// <summary>
        /// Updates the episode status.
        /// </summary>
        /// <param name="showId">The showId.</param>
        /// <param name="episodeId">The episode identifier.</param>
        /// <param name="watchedStatus">if set to <c>true</c> [watched status].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task imdbEpisode.</returns>
        Task<ImdbEpisode> UpdateEpisodeStatus(Guid showId, Guid episodeId, bool watchedStatus, Guid userId);
    }
}