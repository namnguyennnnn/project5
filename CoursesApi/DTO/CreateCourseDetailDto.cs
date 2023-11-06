using System.ComponentModel.DataAnnotations;

namespace CoursesApi.DTO
{
    public class CreateCourseDetailDto
    {
        public string? course_detail_id { get; set; }
        public string? course_id { get; set; }
        public string? course_detail_name { get; set; }
        public int? total_lecture { get; set; }
        public int? course_detail_index { get; set; }
        public List<CreateLectureDto>? LectureDtos { get; set; }
    }
}
