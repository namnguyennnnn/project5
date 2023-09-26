using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO
{
    public class CreateAudioDto
    {
        [Required]            
        public IFormFile audio_url { get; set;}
        [Required]
        public string part1 { get; set; }
        [Required]
        public string part2 { get; set; }
        [Required]
        public string part3 { get; set; }
        [Required]
        public string part4 { get; set; }
    }
}
