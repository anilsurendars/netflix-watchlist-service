namespace NetflexWatchList.Shared.ExternalModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The IMDbSeason.
    /// </summary>
    public class ImdbSeason
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IMDbSeason"/> class.
        /// </summary>
        public ImdbSeason()
        {
            Episodes = new List<ImdbEpisode>();
        }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        /// <value>
        /// The season number.
        /// </value>
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        /// <value>
        /// The episodes.
        /// </value>
        public IList<ImdbEpisode> Episodes { get; set; }
    }
}
