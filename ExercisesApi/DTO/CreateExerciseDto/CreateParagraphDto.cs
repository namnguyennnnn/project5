namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateParagraphDto
    {
        public int? questionIndex { get; set; }
        public IFormFile? paragraphFile { get; set; }
        public string? paragraph_id { get; set; }
        public string? paragraph_url { get; set; }
        public string? question_id { get; set; }      
    }
}
