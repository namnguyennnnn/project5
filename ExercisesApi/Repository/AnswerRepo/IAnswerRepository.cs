using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.AnswerRepo
{
    public interface IAnswerRepository
    {
        Task<Answer> GetAnswersByQuestionIdAsync(string questionId);
        Task<Answer> GetAnswerByIdAsync(string answerId);
        Task AddAnswersAsync(List<Answer> answers);
        Task AddAnswerAsync(Answer answer);
        Task UpdateAnswerAsync(List<GetAnswerToUpdateDto> updateAnswerDtos);
        Task DeleteAnswerAsync(string answerId);
    }
}
