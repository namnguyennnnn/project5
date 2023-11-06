using System.ComponentModel.DataAnnotations;

namespace CoursesApi.DTO
{
    public class CreateEnrollmentDto
    {
        public string? enrollment_id { get; set; } 
        public string? uid { get; set; }
        public string? course_id { get; set; }
        public string? enrollment_date { get; set; }
    }
}
