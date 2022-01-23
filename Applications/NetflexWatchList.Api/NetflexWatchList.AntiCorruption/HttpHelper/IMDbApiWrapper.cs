namespace NetflexWatchList.AntiCorruption.HttpHelper
{
    using IMDbApiLib;
    using IMDbApiLib.Models;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The IMDbApi wrapper.
    /// </summary>
    internal class IMDbApiWrapper
    {
        /// <summary>
        /// The API.
        /// </summary>
        private readonly ApiLib _api;

        /// <summary>
        /// Initializes a new instance of the <see cref="IMDbApiWrapper"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public IMDbApiWrapper(string apiKey)
        {
            _api = new ApiLib(apiKey);
        }

        /// <summary>
        /// Searches the series.
        /// </summary>
        /// <param name="tvShowName">Name of the tv show.</param>
        /// <returns>The SearchData.</returns>
        public async Task<SearchData> SearchSeries(string tvShowName)
        {
            try
            {
                var data = await _api.SearchSeriesAsync(tvShowName);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Searches the title.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The TitleData.</returns>
        public async Task<TitleData> SearchTitle(string id)
        {
            try
            {
                var data = await _api.TitleAsync(id, Language.en);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Searches the episodes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>The SeasonEpisodeData.</returns>
        public async Task<SeasonEpisodeData> SearchEpisodes(string id, int seasonNumber)
        {
            try
            {
                var data = await _api.SeasonEpisodesAsync(id, seasonNumber);

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tops the tv shows.
        /// </summary>
        /// <returns>The top 250 tv shows.</returns>
        public async Task<Top250Data> TopTvShows()
        {
            try
            {
                var data = await _api.Top250TVsAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
