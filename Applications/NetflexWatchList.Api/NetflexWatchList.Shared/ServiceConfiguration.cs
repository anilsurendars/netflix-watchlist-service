namespace NetflexWatchList.Shared
{
    using Microsoft.Extensions.DependencyInjection;
    using NetflexWatchList.Shared.Utilities;
    using NetflexWatchList.Shared.Utilities.Interface;

    /// <summary>
    /// The ServiceConfiguration for Shared project files.
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Adds the shared services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The serviceCollection.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationTime, ApplicationTime>();

            return services;
        }
    }
}
