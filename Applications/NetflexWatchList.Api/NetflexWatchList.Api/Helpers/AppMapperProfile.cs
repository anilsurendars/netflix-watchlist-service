namespace NetflexWatchList.Api.Helpers
{
    using AutoMapper;
    using NetflexWatchList.Api.Models;
    using NetflexWatchList.Shared.ServiceModel;

    /// <summary>
    /// The Application Mapper profile.
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
            CreateMap<UserServiceModel, UserModel>();
            CreateMap<UserModel, UserServiceModel>();
            CreateMap<RegisterModel, UserServiceModel>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src=> BCrypt.Net.BCrypt.HashPassword(src.Password))); 
        }
    }
}
