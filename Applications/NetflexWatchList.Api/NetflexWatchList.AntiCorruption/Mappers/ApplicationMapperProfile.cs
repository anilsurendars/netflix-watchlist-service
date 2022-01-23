namespace NetflexWatchList.AntiCorruption.Mappers
{
    using AutoMapper;
    using IMDbApiLib.Models;
    using NetflexWatchList.Shared.ExternalModels;

    /// <summary>
    /// The Application mapper profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    internal class ApplicationMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMapperProfile"/> class.
        /// </summary>
        public ApplicationMapperProfile()
        {
            IMDbMapperProfile();
        }

        /// <summary>
        /// Users the mapper profile.
        /// </summary>
        private void IMDbMapperProfile()
        {
            CreateMap<SearchResult, ImdbSearchResult>();
            CreateMap<TitleData, ImdbShow>();
            CreateMap<EpisodeShortDetail, ImdbEpisode>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.EpisodeNumber))
                .ForMember(dest => dest.ReleaseDate, opt=> opt.MapFrom(src=> src.Released));

            CreateMap<Top250DataDetail, ImdbTvSeriesData>();
        }
    }
}
