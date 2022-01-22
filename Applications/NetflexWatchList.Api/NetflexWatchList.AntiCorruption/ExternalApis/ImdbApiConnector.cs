namespace NetflexWatchList.AntiCorruption.ExternalApis
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;
    using NetflexWatchList.Shared.OptionModels;

    /// <summary>
    /// The IMDbApi Connector implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.AntiCorruption.ExternalApis.Interface.IImdbApiConnector" />
    public class ImdbApiConnector : IImdbApiConnector
    {
        private readonly IMDbApiOption _option;
        private readonly ILogger<IImdbApiConnector> _logger;

        public ImdbApiConnector(IOptions<IMDbApiOption> option, ILogger<IImdbApiConnector> logger)
        {
            _option = option.Value;
            _logger = logger;
        }

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
