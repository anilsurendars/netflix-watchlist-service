namespace NetflexWatchList.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using NetflexWatchList.Data.Context;
    using NetflexWatchList.Data.Entities;
    using NetflexWatchList.Data.Repositories.Interface;
    using NetflexWatchList.Shared.Utilities.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The show repository implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Data.Repositories.Interface.IShowRepository" />
    public class ShowRepository : IShowRepository
    {
        // <summary>
        /// The db context.
        /// </summary>
        private readonly INetflixWatchlistDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<IShowRepository> _logger;

        /// <summary>
        /// The application time.
        /// </summary>
        private readonly IApplicationTime _appTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="appTime">The appTime.</param>
        public ShowRepository(INetflixWatchlistDbContext context, ILogger<IShowRepository> logger, IApplicationTime appTime)
        {
            _context = context;
            _logger = logger;
            _appTime = appTime;
        }

        /// <summary>
        /// Gets all by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The list of TvShow.
        /// </returns>
        public async Task<IList<TvShow>> GetAllByUser(Guid userId)
        {
            try
            {
                return await Task.FromResult(_context.Shows.Where(x => x.CreatedBy == userId).Include(e=> e.ShowEpisodes).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <returns>
        /// The task TvShow.
        /// </returns>
        public async Task<TvShow> GetShowbyShowId(Guid showId)
        {
            try
            {
                return await Task.FromResult(_context.Shows.Where(x => x.Id == showId).Include(e=> e.ShowEpisodes).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the show.
        /// </summary>
        /// <param name="showEntity">The show entity.</param>
        /// <returns>
        /// The task int.
        /// </returns>
        public async Task<int> SaveShow(TvShow showEntity)
        {
            try
            {
                var isShowExist = _context.Shows.Any(x => x.IMDbId == showEntity.IMDbId && x.CreatedBy == showEntity.CreatedBy);
                if (isShowExist) { return 0; }

                _context.Shows.Add(showEntity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the episode status.
        /// </summary>
        /// <param name="showId">The showId.</param>
        /// <param name="episodeId">The episode identifier.</param>
        /// <param name="watchedStatus">if set to <c>true</c> [watched status].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The task ShowEpisode.
        /// </returns>
        public async Task<ShowEpisode> UpdateEpisodeStatus(Guid showId, Guid episodeId, bool watchedStatus, Guid userId)
        {
            try
            {
                var episode = _context.Episodes.FirstOrDefault(x => x.Id == episodeId && x.ShowId == showId);
                if (episode == null) { return null; }

                episode.IsWatched = watchedStatus;
                episode.UpdatedOn = _appTime.GetDate();
                episode.UpdatedBy = userId;

                _context.Entry(episode).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = await _context.SaveChangesAsync();

                return result > 0 ? episode : null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
