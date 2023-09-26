using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExercisesApi.Model
{
    public class Answer
    {
        [Key]
        [MaxLength(36)]
        public string answer_id { get; set; }
        public string answer_explanation { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string corect_answer { get; set; }

        [MaxLength(36)]
        public string question_id { get; set; }
        [JsonIgnore]
        public Question question { get; set; }
    }
}
