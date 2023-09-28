using AutoMapper;
using ExercisesApi.DTO;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;

namespace ExercisesApi.Helper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseInfo>();
            CreateMap<ExerciseInfo, Exercise>();
            
        }

    }
}
