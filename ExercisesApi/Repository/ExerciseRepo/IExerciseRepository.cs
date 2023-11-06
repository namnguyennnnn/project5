using ExercisesApi.DTO;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ExerciseRepo
{
    public interface IExerciseRepository
    {
        Task<ExerciseInfo> GetExerciseByIdAsync(string exerciseId);
        Task<List<ExerciseInfo>> GetExercisesByCategoryDetailIdAsync(string categoryDetailId);      
        Task<List<ExerciseInfo>> GetExercisesAsync();
        Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId);     
        Task<Exercise> GetExamByIdExerciseAsync(string exerciseId);
        Task AddExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(ExerciseInfo updateExerciseDto);
        Task<List<string>> DeleteExerciseAsync(string exerciseId);
        Task DeleteExercisesByCategoryDetailIdAsync(string categoryDetailId);
        Task DeleteExercisesAsync(List<string> exerciseIds);
    }
}
