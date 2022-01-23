namespace NetflexWatchList.Shared.ExternalModels
{
    /// <summary>
    /// The ImdbTvSeriesData.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Shared.ExternalModels.ImdbSearchResult" />
    public class ImdbTvSeriesData : ImdbSearchResult
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public string Year { get; set; }

        /// <summary>
        /// Gets or sets the im database rating.
        /// </summary>
        /// <value>
        /// The im database rating.
        /// </value>
        public string IMDbRating { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>
        /// The rank.
        /// </value>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the crew.
        /// </summary>
        /// <value>
        /// The crew.
        /// </value>
        public string Crew { get; set; }
    }
}
    