

namespace CoursesApi.DTO
{
    public class CreateRatingDto
    {
        public string? rating_id { get; set; }      
        public string? uid { get; set; }
        public string? course_id { get; set; }
        public float? rating_score { get; set; }
        public string? comment { get; set; }

        public string? user_name { get; set; }
        public string? avartar { get;set; }
    }
}
