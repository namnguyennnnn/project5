namespace ExercisesApi.DTO
{
    public class ExerciseUpdateRequest
    {      
        public string? category_detail_id { get; set; } = string.Empty;
        public string? title_of_exercise { get; set; } = string.Empty;
        public string? exercise_description { get; set; } = string.Empty;     
    }
}
