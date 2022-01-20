namespace NetflexWatchList.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NetflexWatchList.Data.Context;
    using NetflexWatchList.Shared.OptionModels;

    /// <summary>
    /// The ServiceConfiguration for Data project files.
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="option">The option.</param>
        /// <returns>The serviceCollection.</returns>
        public static IServiceCollection AddData(this IServiceCollection services, DataOption option)
        {
            services.AddDbContext<INetflixWatchlistDbContext, NetflixWatchlistDbContext>(opt => opt.UseSqlServer(option.ConnectionString));

            return services;
        }
    }
}
