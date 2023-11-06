using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class Instructors
    {
        [Key, MaxLength(36)]
        public string instructor_id { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public string image_url { get; set; }
        public List<Courses> course { get; set; }
    }
}
