namespace NetflexWatchList.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using NetflexWatchList.Data;
    using NetflexWatchList.Shared.OptionModels;

    /// <summary>
    /// The ServiceConfiguration for Service project files.
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="option">The option.</param>
        /// <returns>The ServiceCollection.</returns>
        public static IServiceCollection AddService(this IServiceCollection services, ServiceOption option)
        {
            services.AddData(ConstructDataOptions(option));

            return services;
        }

        /// <summary>
        /// Constructs the data options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The dataOption.</returns>
        private static DataOption ConstructDataOptions(ServiceOption options)
        {
            return new DataOption()
            {
                ConnectionString = options.DefaultConnectionString
            };
        }
    }
}
