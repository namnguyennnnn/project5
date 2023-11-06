using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class Ratings
    {
        [Key,MaxLength(36)]
        public string rating_id { get; set; }
        [MaxLength(36)]
        public string uid { get; set; }
        [MaxLength(36)]
        public string course_id { get; set; }
        public float rating_score { get; set; }
        public string comment { get; set; }

        public Courses course { get; set; }
    }
}
