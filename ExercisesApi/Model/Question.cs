using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExercisesApi.Model
{
    public class Question
    {
        [Key]
        [MaxLength(36)]
        public string question_id { get; set; }
        public string question_content { get; set; }
        public int index { get; set; }        
        [MaxLength(36)]
        public string exercise_id { get; set; }

        public Image image { get; set; }
        public Paragraph paragraph { get; set; }
        public Exercise exercise { get; set; }
        [JsonIgnore]
        public Answer answer { get; set; }
        [JsonIgnore]
        public List<ExamResultDetail> examResultDetail { get; set; }
    }
}

