using Microsoft.Extensions.DependencyInjection;
using NetflexWatchList.Shared.Utilities;
using NetflexWatchList.Shared.Utilities.Interface;

namespace NetflexWatchList.Shared
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationTime, ApplicationTime>();

            return services;
        }
    }
}
