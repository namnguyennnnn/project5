using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ParagraphRepo
{
    public interface IParagraphRepository
    {
        Task AddParagraphAsync(Paragraph image);
        Task<Paragraph> GetParagraphByQuestionIdAsync(string questionId);
        Task DeleteParagraphAsync(string questionId);
        Task AddParagraphsAsync(List<Paragraph> Paragraphs);
        Task UpdateParagraphsAsync(List<CreateParagraphDto> updateParagraphDtos);
    }
}
