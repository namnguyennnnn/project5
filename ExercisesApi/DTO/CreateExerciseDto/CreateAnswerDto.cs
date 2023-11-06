using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateAnswerDto
    {
        public string? answer_id { get; set;}
        [Required]
        public string answer_explanation { get; set; }
        [Required]
        public string a { get; set; }
        [Required]
        public string b { get; set; }
        [Required]
        public string c { get; set; }
        [Required]
        public string d { get; set; }
        [Required]
        public string corect_answer { get; set; }
    }
}
