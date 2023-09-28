namespace ExercisesApi.DTO.UpdateExerciseRequest
{
    public class UpdateParagraphDto
    {    
        public string? paragraph_id { get; set; }
        public string? paragraph_url { get; set; }      
        public string? question_id { get; set; }
        public IFormFile? paragraphFile{ get; set; }
    }
}
