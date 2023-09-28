namespace ExercisesApi.DTO.UpdateExerciseRequest
{
    public class UpdateQuestionDto
    {
        public string? question_id { get; set; }
        public string? question_content { get; set; }
        public string? exercise_id { get; set; }
        public int index { get; set; }
    }
}
