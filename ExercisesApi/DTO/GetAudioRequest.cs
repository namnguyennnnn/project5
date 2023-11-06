namespace ExercisesApi.DTO
{
    public class GetAudioRequest
    {
        public string audioUrl { get; set; }
        public List<string> timeRange { get; set; }
    }
}
