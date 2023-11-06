using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Model
{
    public class Lectures
    {
        [Key,MaxLength(36)]
        public string lecture_id{ get; set; }
        public int lecture_index { get; set; }
        public string lecture_title { get; set; }
        public string content { get; set; }
        public string video_url { get; set; }

        [MaxLength(36)]
        public string course_detail_id { get; set; }

        public CourseDetails courseDetail { get; set; }
    }
}
