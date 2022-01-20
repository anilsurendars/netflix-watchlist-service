namespace NetflexWatchList.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NetflexWatchList.Data.Context;
    using NetflexWatchList.Data.Repositories;
    using NetflexWatchList.Data.Repositories.Interface;
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

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
