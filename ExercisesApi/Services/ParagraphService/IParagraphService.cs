using ExercisesApi.Model;

namespace ExercisesApi.Services.ParagraphService
{
    public interface IParagraphService
    {
        Task<Paragraph> CreateParagraph(IFormFile url, string questionId);
        Task<Paragraph> CreateParagraphByData(byte[] paragraphData, string questionId);
    }
}
