namespace NetflexWatchList.Shared.ExternalModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The IMDbShow.
    /// </summary>
    public class ImdbShow : ImdbSearchResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IMDbShow"/> class.
        /// </summary>
        public ImdbShow()
        {
            Seasons = new List<ImdbSeason>();
        }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        public string Genres { get; set; }

        /// <summary>
        /// Gets or sets the seasons.
        /// </summary>
        /// <value>
        /// The seasons.
        /// </value>
        public IList<ImdbSeason> Seasons { get; set; }
    }
}
