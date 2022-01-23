namespace NetflexWatchList.Shared.ExternalModels
{
    /// <summary>
    /// THe IMDbSearchResult.
    /// </summary>
    public class ImdbSearchResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the full title.
        /// </summary>
        /// <value>
        /// The full title.
        /// </value>
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the release data.
        /// </summary>
        /// <value>
        /// The release data.
        /// </value>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the plot.
        /// </summary>
        /// <value>
        /// The plot.
        /// </value>
        public string Plot { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
