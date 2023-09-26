using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.Model
{
    public class Exercise
    {
        [Key]
        [MaxLength(36)]
        public string exercise_id { get; set; }
        public string category_detail_id { get; set; }
        public string title_of_exercise { get; set; }
        public string exercise_description { get; set; }
        public DateTime? create_at { get; set; } = default(DateTime?);
        
        public Audio audio { get; set; }
        public List<Question> questions { get; set; }
    }
}
