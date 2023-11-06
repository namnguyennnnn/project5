namespace CoursesApi.DTO
{
    public class CreateInstructorDto
    {
        public string? instructor_id { get; set; }
        public string? name { get; set; }
        public string? bio { get; set; }
        public string? image_url { get; set; }
        public IFormFile? imageFile { get; set; }
        public List<CreateCourseDto>? courseDtos { get; set; }
    }
}
