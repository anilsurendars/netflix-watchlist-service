using System;
using System.Collections.Generic;

namespace ConsoleApp1.IMDbApiPackage_POC
{
    public class IMDbResultBase
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ReleaseData { get; set; }
        public string Plot { get; set; }

    }
    internal class IMDbShowResponse: IMDbResultBase
    {
        public IMDbShowResponse()
        {
            Seasons = new List<IMDbSeason>();
        }

        public string Genres { get; set; }

        public IList<IMDbSeason> Seasons { get; set; }
    }

    public class IMDbSeason
    {
        public IMDbSeason()
        {
            Episodes = new List<IMDbEpisode>();
        }
        public int SeasonNumber { get; set; }
        public IList<IMDbEpisode> Episodes { get; set; }
    }

    public class IMDbEpisode : IMDbResultBase
    {
        public string Number { get; set; }

    }

}
