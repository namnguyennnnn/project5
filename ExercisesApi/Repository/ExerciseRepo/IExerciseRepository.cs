using ExercisesApi.DTO;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ExerciseRepo
{
    public interface IExerciseRepository
    {
        Task<List<ExerciseInfo>> GetExercisesByCategoryDetailIdAsync(string categoryDetailId);      
        Task<List<ExerciseInfo>> GetExercisesAsync();
        Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId);
        Task<(List<Question>, List<Answer>)> GetQuestionsAndAnswersByExerciseIdAsync(string exerciseId);
        Task<Exercise> GetExamByIdExerciseAsync(string exerciseId);
        Task AddExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(ExerciseInfo updateExerciseDto);
        Task DeleteExerciseAsync(string exerciseId);
        Task DeleteExercisesByCategoryDetailIdAsync(string categoryDetailId);
    }
}
