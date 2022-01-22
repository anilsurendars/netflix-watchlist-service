using ConsoleApp1.IMDbApiPackage_POC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main()
        {
            //await Check();

            await LibraryValidation();
        }

        static async Task LibraryValidation()
        {
            var imdbPackagePoc = new IMDbApiConnector();

            //General search
            //var dd = await imdbPackagePoc.SearchShow("Mentalist");

            //Exact serial search
            var imdbModel = new IMDbShowResponse();
            
            var title = await imdbPackagePoc.SearchTitle("tt1196946");

            imdbModel.Id = title.Id;
            imdbModel.Title = title.Title;
            imdbModel.Genres = title.Genres;
            imdbModel.Image = title.Image;
            imdbModel.ReleaseData = title.ReleaseDate;
            imdbModel.Plot = title.Plot;
            for (int i = 0; i < title.TvSeriesInfo.Seasons.Count; i++)
            {
                var seasonNumber = int.Parse(title.TvSeriesInfo.Seasons[i]);
                var season = new IMDbSeason() { SeasonNumber = seasonNumber };

                var episodes = await imdbPackagePoc.SearchEpisodes(title.Id, seasonNumber);

                foreach (var episode in episodes.Episodes)
                {
                    season.Episodes.Add(new IMDbEpisode()
                    {
                        Id = episode.Id,
                        Title = episode.Title,
                        Number = episode.EpisodeNumber,
                        Plot = episode.Plot,
                        Image = episode.Image,
                        ReleaseData = episode.Released
                    });
                }
                imdbModel.Seasons.Add(season);
            }


            //var advanceSearch = await imdbPackagePoc.AdvanceSearchForEpisodes();
            //"tt1196946" 
        }

        //static async Task Check()
        //{
        //    var services = new ServiceCollection();

        //    services.AddHttpClient("IMDBApi", 
        //        o=> 
        //        {
        //            o.BaseAddress = new Uri("https://imdb-api.com");
        //            o.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
        //        });

        //    services.AddTransient<IMDBApi>();

        //    // Register a HTTP Client
        //    //services.AddHttpClient();

        //    //services.AddTransient<IMDBApi>();

        //    var serviceProvider = services.BuildServiceProvider();


        //    // Get a HTTP Client and make a request
        //    var imdbApi = serviceProvider.GetRequiredService<IMDBApi>();
        //    var data = await imdbApi.GetData();
        //}
    }
}
