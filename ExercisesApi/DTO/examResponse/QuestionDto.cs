using CloudinaryDotNet.Actions;

namespace ExercisesApi.DTO.examResponse
{
    public class QuestionDto
    {
        public string? question_id { get; set; }
        public string? question_content { get; set; }
        public int index { get; set; }
        public string? corect_answer { get; set; }
        public string? paragraph_url { get; set; }      
        public string? answer_explanation { get; set; }
        public AnswerDto? answer { get; set; }
        public string? image_url { get; set; }
    }
}
