namespace NetflexWatchList.AntiCorruption.ExternalApis
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;
    using NetflexWatchList.AntiCorruption.HttpHelper;
    using NetflexWatchList.Shared.ExternalModels;
    using NetflexWatchList.Shared.OptionModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The IMDbApi Connector implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.AntiCorruption.ExternalApis.Interface.IImdbApiConnector" />
    public class ImdbApiConnector : IImdbApiConnector
    {
        private readonly IMDbApiOption _option;
        private readonly ILogger<IImdbApiConnector> _logger;
        private readonly IMDbApiWrapper _imdbApi;
        private readonly IMapper _mapper;

        public ImdbApiConnector(IOptions<IMDbApiOption> option, ILogger<IImdbApiConnector> logger, IMapper mapper)
        {
            _option = option.Value;
            _logger = logger;
            _mapper = mapper;

            _imdbApi = new IMDbApiWrapper(_option.ApiKey);
        }

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>
        /// The list of IMDbSearchResult.
        /// </returns>
        public async Task<IList<ImdbSearchResult>> GetShows(string title)
        {
            var titleData = await _imdbApi.SearchSeries(title);
            return _mapper.Map<List<ImdbSearchResult>>(titleData.Results);
        }

        /// <summary>
        /// Gets the show by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The IMDbShow.
        /// </returns>
        public async Task<ImdbShow> GetShowById(string id)
        {
            var showData = await _imdbApi.SearchTitle(id);
            var show = _mapper.Map<ImdbShow>(showData);
            foreach (var item in showData.TvSeriesInfo.Seasons)
            {
                var seasonNumber = int.Parse(item);
                var season = new ImdbSeason() { SeasonNumber = seasonNumber };

                var episodeResult = await _imdbApi.SearchEpisodes(id, seasonNumber);
                var episodes = _mapper.Map<List<ImdbEpisode>>(episodeResult.Episodes);
                season.Episodes = episodes;

                show.Seasons.Add(season);
            }

            return show;
        }

        /// <summary>
        /// Gets the episodes.
        /// </summary>
        /// <param name="imdbId">The imdb identifier.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <returns>
        /// The list of ImdbEpisode.
        /// </returns>
        public async Task<IList<ImdbEpisode>> GetEpisodes(string imdbId, int seasonNumber)
        {
            var episodeData = await _imdbApi.SearchEpisodes(imdbId, seasonNumber);
            return _mapper.Map<List<ImdbEpisode>>(episodeData.Episodes);
        }

        /// <summary>
        /// Gets all shows.
        /// </summary>
        /// <returns>
        /// The list of IMDb tv series data.
        /// </returns>
        public async Task<IList<ImdbTvSeriesData>> GetAllShows()
        {
            var top250Shows = await _imdbApi.TopTvShows();
            return _mapper.Map<List<ImdbTvSeriesData>>(top250Shows.Items);
        }
    }
}
