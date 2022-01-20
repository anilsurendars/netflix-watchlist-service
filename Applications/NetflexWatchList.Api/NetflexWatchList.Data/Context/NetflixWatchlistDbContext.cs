namespace NetflexWatchList.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using NetflexWatchList.Data.Entities;

    /// <summary>
    /// The NetflixWatchlist database context implementation.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="NetflexWatchList.Data.Context.INetflixWatchlistDbContext" />
    public class NetflixWatchlistDbContext : DbContext, INetflixWatchlistDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetflixWatchlistDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public NetflixWatchlistDbContext(DbContextOptions<NetflixWatchlistDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        ///// <summary>
        ///// Gets or sets the shows.
        ///// </summary>
        ///// <value>
        ///// The shows.
        ///// </value>
        //public DbSet<object> Shows { get; set; }

        ///// <summary>
        ///// Gets or sets the episodes.
        ///// </summary>
        ///// <value>
        ///// The episodes.
        ///// </value>
        //public DbSet<object> Episodes { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
