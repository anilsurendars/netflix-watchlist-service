﻿namespace NetflexWatchList.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The NetflixWatchlist database context interface.
    /// </summary>
    public interface INetflixWatchlistDbContext
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>The int.</returns>
        int SaveChanges();

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        DbSet<object> Users { get; set; }

        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        /// <value>
        /// The shows.
        /// </value>
        DbSet<object> Shows { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        /// <value>
        /// The episodes.
        /// </value>
        DbSet<object> Episodes { get; set; }
    }
}
