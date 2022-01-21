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
        /// <returns>The string.</returns>
        string GetShows(string title);

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The string.</returns>
        string GetEpisodes(string imdbId, int seasonNumber);
    }
}
