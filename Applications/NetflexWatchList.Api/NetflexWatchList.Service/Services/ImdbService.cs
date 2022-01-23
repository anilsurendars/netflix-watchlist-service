namespace NetflexWatchList.Service.Services
{
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;
    using NetflexWatchList.Data.Repositories.Interface;
    using NetflexWatchList.Service.Mapper;
    using NetflexWatchList.Service.Services.Interface;
    using NetflexWatchList.Shared.ExternalModels;
    using System;
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
        private readonly IImdbApiConnector _apiConnector;

        /// <summary>
        /// The show repo.
        /// </summary>
        private readonly IShowRepository _showRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImdbService"/> class.
        /// </summary>
        /// <param name="imdbApiConnector">The imdb API connector.</param>
        /// <param name="showRepo">The show repo.</param>
        public ImdbService(IImdbApiConnector imdbApiConnector, IShowRepository showRepo)
        {
            _apiConnector = imdbApiConnector;
            _showRepo = showRepo;
        }

        /// <summary>
        /// Searches the show by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>
        /// The list of IMDbSearchResult.
        /// </returns>
        public async Task<IList<ImdbSearchResult>> SearchShowByTitle(string title)
        {
            return await _apiConnector.SearchShowByTitle(title);
        }

        /// <summary>
        /// Gets the show by imdb identifier.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <returns>
        /// The ImdbShow.
        /// </returns>
        public async Task<ImdbShow> GetShowByIMDbId(string imdbId)
        {
            return await _apiConnector.GetShowByIMDbId(imdbId);
        }

        /// <summary>
        /// Gets the episodes by imdb identifier and season number.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>
        /// The list of ImdbEpisode.
        /// </returns>
        public async Task<IList<ImdbEpisode>> GetEpisodesByIMDbIdAndSeasonNumber(string imdbId, int seasonNumber)
        {
            return await _apiConnector.GetEpisodesByIMDbIdAndSeasonNumber(imdbId, seasonNumber);
        }

        /// <summary>
        /// Gets all top 250 IMDb shows.
        /// </summary>
        /// <returns>
        /// The list of IMDb tv series data.
        /// </returns>
        public async Task<IList<ImdbTvSeriesData>> GetAllIMDbShows()
        {
            return await _apiConnector.GetAllShows();
        }

        /// <summary>
        /// Saves the show to system.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task int.</returns>
        public async Task<int> SaveShowToSystem(string imdbId, string userId)
        {
            var data = await _apiConnector.GetShowByIMDbId(imdbId);

            var entity = data.ToEntity(userId);

            var result = await _showRepo.SaveShow(entity);

            return result;
        }

        /// <summary>
        /// Gets the show from system by identifier.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <returns>The task imdbShow.</returns>
        public async Task<ImdbShow> GetShowFromSystemById(Guid showId)
        {
            var showEntity = await _showRepo.GetShowbyShowId(showId);

            var servideModel = showEntity.ToServiceModel();

            return servideModel;
        }

        /// <summary>
        /// Gets all shows from system by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task list of imdbshows.</returns>
        public async Task<IList<ImdbShow>> GetAllShowsFromSystemByUserId(Guid userId)
        {
            var userShows = await _showRepo.GetAllByUser(userId);
            var result = new List<ImdbShow>();

            foreach (var showEntity in userShows)
            {
                result.Add(showEntity.ToServiceModel());
            }

            return result;
        }

        /// <summary>
        /// Updates the episode status.
        /// </summary>
        /// <param name="showId">The showId.</param>
        /// <param name="episodeId">The episode identifier.</param>
        /// <param name="watchedStatus">if set to <c>true</c> [watched status].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The task imdbEpisode.
        /// </returns>
        public async Task<ImdbEpisode> UpdateEpisodeStatus(Guid showId, Guid episodeId, bool watchedStatus, Guid userId)
        {
            var episode = await _showRepo.UpdateEpisodeStatus(showId, episodeId, watchedStatus, userId);

            return episode.ToServiceModel();
        }
    }
}
