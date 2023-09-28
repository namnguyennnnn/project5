using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.Model
{
    public class Paragraph
    {
        [Key]
        [MaxLength(36)]
        public string paragraph_id { get; set; }

        public string? paragraph_url { get; set; }

        [MaxLength(36)]
        public string question_id { get; set; }

        public Question question { get; set; }
    }
}
