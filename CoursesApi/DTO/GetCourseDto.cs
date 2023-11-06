namespace CoursesApi.DTO
{
    public class GetCourseDto
    {
        public string? course_id { get; set; }
        public string? course_name { get; set; }
        public string? course_description { get; set; }
        public string? course_image_url { get; set; }
        public int? course_price { get; set; }
        public int? total_member { get; set; }
        public int? total_rating { get; set; }
        public float? average_score_rating { get; set; }
        public string? course_goal { get; set; }
        public string? course_created_at { get; set; }
        public string? instructor_id { get; set; }
        public bool? isEnroll { get; set; }
        public CreateInstructorDto? instructor { get; set; }
        public List<CreateCourseDetailDto>? courseDetailDtos { get; set; }
        public List<CreateRatingDto>? ratingDtos { get; set; }
    }
}
