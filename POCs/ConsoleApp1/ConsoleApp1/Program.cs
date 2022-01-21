using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main()
        {
            await Check();
        }

        static async Task Check()
        {
            var services = new ServiceCollection();

            services.AddHttpClient("IMDBApi", 
                o=> 
                {
                    o.BaseAddress = new Uri("https://imdb-api.com");
                    o.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
                });

            services.AddTransient<IMDBApi>();

            // Register a HTTP Client
            //services.AddHttpClient();

            //services.AddTransient<IMDBApi>();

            var serviceProvider = services.BuildServiceProvider();

           
            // Get a HTTP Client and make a request
            var imdbApi = serviceProvider.GetRequiredService<IMDBApi>();
            var data = await imdbApi.GetData();
        }
    }
}
