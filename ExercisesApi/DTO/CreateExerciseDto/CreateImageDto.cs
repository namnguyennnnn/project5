namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateImageDto
    {
        public int? questionIndex { get; set; }
        public IFormFile? imageFile { get; set; }
        public string? image_id { get; set; }
        public string? image_url { get; set; }
        public string? question_id { get; set; }
    }
}
