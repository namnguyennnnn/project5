using System.ComponentModel.DataAnnotations;


namespace ExercisesApi.Model
{
    public class Image
    {
        [Key]
        [MaxLength(36)]
        public string image_id { get; set; }
        public string image_url { get; set; }
        [MaxLength(36)]
        public string question_id { get; set; }

        public Question question { get; set; }
    }
}
