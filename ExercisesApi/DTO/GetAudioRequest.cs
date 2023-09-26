namespace ExercisesApi.DTO
{
    public class GetAudioRequest
    {
        public string AudioUrl { get; set; }
        public List<string> TimeRange { get; set; }
    }
}
