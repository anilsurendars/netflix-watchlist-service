using IMDbApiLib;
using IMDbApiLib.Models;
using System.Threading.Tasks;

namespace ConsoleApp1.IMDbApiPackage_POC
{
    internal class IMDbApiConnector
    {
        private readonly ApiLib apiLib;
        public IMDbApiConnector()
        {
            apiLib = new ApiLib("k_1uvuee84");
        }

        public async Task<SearchData> SearchShow(string tvShowName)
        {
            // Search
            var data = await apiLib.SearchSeriesAsync(tvShowName);

            return data;
        }

        public async Task<TitleData> SearchTitle(string id)
        {
            // TitleAsync
            var data = await apiLib.TitleAsync(id, Language.en);

            return data;
        }

        public async Task<SeasonEpisodeData> SearchEpisodes(string id, int seasonNumber)
        {
            var data = await apiLib.SeasonEpisodesAsync(id, seasonNumber);

            return data;
        }

        public async Task<Top250Data> Top250TvSerials()
        {
            var data = await apiLib.Top250TVsAsync();

            return data;
        }


        public async Task<object> AdvanceSearchForEpisodes()
        {
            // AdvancedSearch
            var input = new AdvancedSearchInput();
            input.Genres = AdvancedSearchGenre.Action | AdvancedSearchGenre.Adventure;
            input.Sort = AdvancedSearchSort.User_Rating_Descending;
            input.ReleaseDateFrom = "2010-01-01";
            input.NumberOfVotesFrom = 5000;

            input.Languages = AdvancedSearchLanguage.English | AdvancedSearchLanguage.French;
            // OR - Multiple languages
            //input.LanguagesStr = $"{AdvancedSearchLanguage.English.GetDescription()},{AdvancedSearchLanguage.French.GetDescription()}";

            input.Countries = AdvancedSearchCountry.United_States;
            // OR - Multiple countries
            //input.CountriesStr = $"{AdvancedSearchCountry.United_States},{AdvancedSearchCountry.France},{AdvancedSearchCountry.United_Kingdom}";

            string queryString = input.ToString();
            var advancedSearchdata = await apiLib.AdvancedSearchAsync(input);

            return advancedSearchdata;
        }
    }
}
