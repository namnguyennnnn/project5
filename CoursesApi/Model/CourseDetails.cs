using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class CourseDetails
    {
        [Key,MaxLength(36)]
        public string course_detail_id {  get; set; }
        [MaxLength(36)]
        public string course_id {  get; set; }
        public int course_detail_index {  get; set; }
        public string course_detail_name { get; set; }
        public int total_lecture { get; set; }

        public Courses course {  get; set; }
        public List<Lectures> lectures { get; set; }    
    }
}
