using ExercisesApi.DTO;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.QuestionRepo
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuestionsByExerciseIdAsync(string exerciseId);
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task AddQuestionsAsync(List<Question> questions);
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(List<UpdateQuestionDto> updateQuestionDtos);
        Task DeleteQuestionAsync(string questionId);
        Task DeleteQuestionByIdExerciseAsync(string exerciseId);
       
    }
}
