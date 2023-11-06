
namespace ExercisesApi.DTO.examResponse
{
    public class PartResponse
    {
        public string? exercise_id { get; set; }
        public string? category_detail_id { get; set; }
        public string? title_of_exercise { get; set; }
        public string? exercise_description { get; set; }
        public string? category_name { get; set; }
        public string? category_detail_name { get; set; }
        public Dictionary<string, List<QuestionDto>>? question { get; set; }                    
    }
}
