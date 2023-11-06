using AutoMapper;
using ExercisesApi.DTO;
using ExercisesApi.Model;

namespace ExercisesApi.Helper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseInfo>();
            CreateMap<ExerciseInfo, Exercise>();
            CreateMap<CreateExamResultDto, ExamResult>().ReverseMap();
            

            CreateMap<CreateExamResultDetailDto,ExamResultDetail>().ReverseMap();
        }

    }
}
