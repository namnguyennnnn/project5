
using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateQuestionDto
    {
        [Required]
        public string question_content { get; set; }
        [Required]
        public int index { get; set; }

        public CreateAnswerDto answer { get; set; }
    }
}
