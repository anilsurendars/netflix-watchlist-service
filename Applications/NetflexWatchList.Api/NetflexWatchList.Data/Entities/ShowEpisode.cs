namespace NetflexWatchList.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The ShowEpisode.
    /// </summary>
    [Table(nameof(ShowEpisode))]
    public class ShowEpisode
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the show identifier.
        /// </summary>
        /// <value>
        /// The show identifier.
        /// </value>
        public Guid ShowId { get; set; }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        /// <value>
        /// The season number.
        /// </value>
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        /// <value>
        /// The episode number.
        /// </value>
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode identifier.
        /// </summary>
        /// <value>
        /// The episode identifier.
        /// </value>
        public string EpisodeId { get; set; }

        /// <summary>
        /// Gets or sets the episode title.
        /// </summary>
        /// <value>
        /// The episode title.
        /// </value>
        public string EpisodeTitle { get; set; }

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
        public string ReleaseData { get; set; }

        /// <summary>
        /// Gets or sets the plot.
        /// </summary>
        /// <value>
        /// The plot.
        /// </value>
        public string Plot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is watched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is watched; otherwise, <c>false</c>.
        /// </value>
        public bool IsWatched { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the tv show.
        /// </summary>
        /// <value>
        /// The tv show.
        /// </value>
        [ForeignKey("ShowId")]
        public virtual TvShow TvShow { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [ForeignKey("CreatedBy")]
        public virtual User User { get; set; }
    }
}
