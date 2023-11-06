using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class Enrollments
    {
        [Key,MaxLength(36)]
        public string enrollment_id { get; set; }
        [MaxLength(36)]
        public string uid { get; set; }
        [MaxLength(36)]
        public string course_id { get; set; }
        public string enrollment_date { get; set; }

        public Courses course { get; set; }
    }
}
