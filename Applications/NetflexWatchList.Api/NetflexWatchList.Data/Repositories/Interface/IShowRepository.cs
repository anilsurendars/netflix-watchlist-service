namespace NetflexWatchList.Data.Repositories.Interface
{
    using NetflexWatchList.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Show Repository interface.
    /// </summary>
    public interface IShowRepository
    {
        /// <summary>
        /// Saves the show.
        /// </summary>
        /// <param name="showEntity">The show entity.</param>
        /// <returns>The task int.</returns>
        Task<int> SaveShow(TvShow showEntity);

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <param name="showId">The show identifier.</param>
        /// <returns>The task TvShow.</returns>
        Task<TvShow> GetShowbyShowId(Guid showId);

        /// <summary>
        /// Gets all by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The list of TvShow.</returns>
        Task<IList<TvShow>> GetAllByUser(Guid userId);

        /// <summary>
        /// Updates the episode status.
        /// </summary>
        /// <param name="showId">The showId.</param>
        /// <param name="episodeId">The episode identifier.</param>
        /// <param name="watchedStatus">if set to <c>true</c> [watched status].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The task ShowEpisode.</returns>
        Task<ShowEpisode> UpdateEpisodeStatus(Guid showId, Guid episodeId, bool watchedStatus, Guid userId);
    }
}
