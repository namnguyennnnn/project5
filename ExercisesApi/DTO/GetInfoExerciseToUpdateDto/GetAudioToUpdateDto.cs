

namespace ExercisesApi.DTO.GetInfoExerciseToUpdateDto
{
    public class GetAudioToUpdateDto
    {
        public string? audio_id { get; set; }

        public string? audio_url { get; set; }

        public IFormFile? audioFile { get; set; }
       
        public string? part1 { get; set; }
       
        public string? part2 { get; set; }
       
        public string? part3 { get; set; }
       
        public string? part4 { get; set; }
    }
}
