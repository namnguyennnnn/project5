using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class Courses
    {
        [Key]
        [MaxLength(36)]
        public string course_id { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set; }
        public string course_image_url { get; set; }
        public int course_price { get; set; }
        public int total_member { get; set; }
        public float average_score_rating {  get; set; }
        public int total_rating { get; set; }
        public string? course_goal { get; set; }
        public string course_created_at { get; set; }
        [MaxLength(36)]
        public string instructor_id { get; set; }   
        
        public Enrollments enrollment { get; set; }
        public Instructors instructor { get; set; }
        public List<CourseDetails> courseDetails { get; set; }     
        public List<Ratings> ratings { get; set; }
    }
}
