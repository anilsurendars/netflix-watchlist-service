namespace NetflexWatchList.Service.Mapper
{
    using AutoMapper;
    using NetflexWatchList.Data.Entities;
    using NetflexWatchList.Shared.ServiceModel;

    /// <summary>
    /// The application mapper profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public partial class ApplicationMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMapperProfile"/> class.
        /// </summary>
        public ApplicationMapperProfile()
        {
            UserMapperProfile();
        }

        /// <summary>
        /// Users the mapper profile.
        /// </summary>
        private void UserMapperProfile()
        {
            CreateMap<UserServiceModel, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress));
            CreateMap<User, UserServiceModel>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
        }
    }
}
