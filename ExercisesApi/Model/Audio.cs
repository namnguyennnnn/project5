using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.Model
{
    public class Audio
    {
        [Key]
        [MaxLength(36)]
        public string audio_id { get; set; }
        public string audio_url { get; set; }
        public string part1 { get; set; }
        public string part2 { get; set; }
        public string part3 { get; set; }
        public string part4 { get; set; }
        [MaxLength(36)]
        public string exercise_id { get; set; }
        
        public Exercise exercise { get; set;}
    }
}
