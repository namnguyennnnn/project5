
namespace CoursesApi.DTO
{
    public class CreateLectureDto
    {
       
        public string? lecture_id { get; set; }
        public int? lecture_index { get; set; }
        public string? lecture_title { get; set; }
        public string? content { get; set; }
        public string? video_url { get; set; }
        public string? course_detail_id { get; set; }

        public int? total_comment {  get; set; }

        public IFormFile? videoFile { get; set; }
    }
}
