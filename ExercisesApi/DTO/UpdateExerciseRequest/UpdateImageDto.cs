namespace ExercisesApi.DTO.UpdateExerciseRequest
{
    public class UpdateImageDto
    {
        public string? image_id { get; set; }
        public string? image_url { get; set; }
        public string? question_id { get; set; }
        public IFormFile? imageFile { get; set; }
    }
}
