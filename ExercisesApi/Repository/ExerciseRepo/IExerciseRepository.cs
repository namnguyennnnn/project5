using ExercisesApi.DTO;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ExerciseRepo
{
    public interface IExerciseRepository
    {
        Task<List<ExerciseInfo>> GetExercisesByCategoryDetailIdAsync(string categoryDetailId);
        Task<Exercise> GetExerciseByIdAsync(string exerciseId);
        Task AddExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Exercise exercise);
        Task DeleteExerciseAsync(string exerciseId);
        Task<(List<Question>, List<Answer>)> GetQuestionsAndAnswersByExerciseIdAsync(string exerciseId);
        Task<Exercise> GetExamByIdExerciseAsync(string exerciseId);
        Task DeleteExercisesByCategoryDetailIdAsync(string categoryDetailId);
    }
}
