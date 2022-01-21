namespace NetflexWatchList.AntiCorruption.ExternalApis
{
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;

    /// <summary>
    /// The IMDbApi Connector implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.AntiCorruption.ExternalApis.Interface.IImdbApiConnector" />
    public class ImdbApiConnector : IImdbApiConnector
    {
        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>
        /// The string.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetEpisodes(string imdbId, int seasonNumber)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>
        /// The string.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetShows(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
