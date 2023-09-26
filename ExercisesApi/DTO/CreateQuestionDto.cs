using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO
{
    public class CreateQuestionDto
    {
        [Required]
        public string question_content { get; set; }
        [Required]
        public int index { get; set; }
        public string? paragraph { get; set; }
    }
}
