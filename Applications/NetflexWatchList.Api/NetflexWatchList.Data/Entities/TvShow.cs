namespace NetflexWatchList.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The TvShow.
    /// </summary>
    [Table(nameof(TvShow))]
    public class TvShow
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
        /// Gets or sets the im database identifier.
        /// </summary>
        /// <value>
        /// The imdb identifier.
        /// </value>
        public string IMDbId { get; set; }

        /// <summary>
        /// Gets or sets the im database identifier.
        /// </summary>
        /// <value>
        /// The im database identifier.
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

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        public string Genres { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the show episodes.
        /// </summary>
        /// <value>
        /// The show episodes.
        /// </value>
        public virtual ICollection<ShowEpisode> ShowEpisodes { get; set; }

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
