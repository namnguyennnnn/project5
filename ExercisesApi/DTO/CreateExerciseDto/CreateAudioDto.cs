using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateAudioDto
    {
        public string? audio_id { get; set; }

        public IFormFile? audioFile { get; set; }

        public string? exercise_id { get; set; }

        public string? audio_url { get; set; }
        
        public string? part1 { get; set; }
       
        public string? part2 { get; set; }
        
        public string? part3 { get; set; }
        
        public string? part4 { get; set; }
        public byte[]? audioData { get; set; }
    }
}
