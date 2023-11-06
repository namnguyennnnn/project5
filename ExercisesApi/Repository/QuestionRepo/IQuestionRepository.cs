
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.examResponse;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.QuestionRepo
{
    public interface IQuestionRepository
    {
        Task<List<QuestionDto>> GetQuestionsByExerciseIdAsync(string exerciseId);
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task AddQuestionsAsync(List<Question> questions);
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(List<CreateQuestionDto> updateQuestionDtos);
        Task DeleteQuestionAsync(string questionId);
        Task DeleteQuestionByIdExerciseAsync(string exerciseId);
       
    }
}
