namespace NetflexWatchList.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using NetflexWatchList.Data.Entities;
    using System.Threading;
    using System.Threading.Tasks;

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
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task int.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        DbSet<User> Users { get; set; }

        ///// <summary>
        ///// Gets or sets the shows.
        ///// </summary>
        ///// <value>
        ///// The shows.
        ///// </value>
        //DbSet<object> Shows { get; set; }

        ///// <summary>
        ///// Gets or sets the episodes.
        ///// </summary>
        ///// <value>
        ///// The episodes.
        ///// </value>
        //DbSet<object> Episodes { get; set; }
    }
}
