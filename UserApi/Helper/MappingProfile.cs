using AutoMapper;
using UserApi.DTO;
using UserApi.Model;

namespace UserApi.Helper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<GetUserDto, User>()
            .ForMember(dest => dest.user_name, opt => opt.MapFrom(src => src.username))
            .ForMember(dest => dest.is_verified, opt => opt.MapFrom(src => src.isVerified));

            CreateMap<User, GetUserDto>()
            .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.user_name))
            .ForMember(dest => dest.isVerified, opt => opt.MapFrom(src => src.is_verified));

            CreateMap<CreateCommentDto,Comment>().ReverseMap();        
        }

    }
}
