using AutoMapper;
using UsersApi.DTO;
using UsersApi.DTO.ForGetCommentByExercise;
using UsersApi.Model;

namespace UsersApi.Helper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<GetUserDto, User>().ReverseMap(); 

            CreateMap<CreateCommentDto,Comment>().ReverseMap();        
        }

    }
}
