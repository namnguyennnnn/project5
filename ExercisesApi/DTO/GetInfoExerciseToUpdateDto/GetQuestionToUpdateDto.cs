
using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO.GetInfoExerciseToUpdateDto
{
    public class GetQuestionToUpdateDto
    {
        
        public string? question_id { get; set; }
    
        public string? question_content { get; set; }
        
        public int? index { get; set; }
        public GetAnswerToUpdateDto? answer { get; set; }
        public GetImageToUpdateDto? imageDto { get; set; }
        public GetParagraphToUpdateDto? paragraphDto { get; set; }
    }
}
