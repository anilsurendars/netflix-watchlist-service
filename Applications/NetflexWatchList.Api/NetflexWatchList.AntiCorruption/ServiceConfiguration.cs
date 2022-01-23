namespace NetflexWatchList.AntiCorruption
{
    using Microsoft.Extensions.DependencyInjection;
    using NetflexWatchList.AntiCorruption.ExternalApis;
    using NetflexWatchList.AntiCorruption.ExternalApis.Interface;

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
        public static IServiceCollection AddAntiCurruption(this IServiceCollection services)
        {
            services.AddTransient<IImdbApiConnector, ImdbApiConnector>();
            return services;
        }
    }
}
