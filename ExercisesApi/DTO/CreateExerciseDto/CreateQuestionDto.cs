
using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateQuestionDto
    {
        public string? question_id { get; set; }
        public string? exercise_id {  get; set; }
        
        public string? question_content { get; set; }
        
        public int? index { get; set; }

        public CreateAnswerDto? answer { get; set; }
    }
}
