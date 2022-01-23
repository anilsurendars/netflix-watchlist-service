namespace NetflexWatchList.Shared.ExternalModels
{
    /// <summary>
    /// The IMDbEpisode.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Data.ExternalModels.IMDbSearchResult" />
    public class ImdbEpisode : ImdbSearchResult
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number { get; set; }
    }
}
