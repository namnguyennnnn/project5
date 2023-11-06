

using System.ComponentModel.DataAnnotations;


namespace ExercisesApi.Model
{
    public class ExamResultDetail
    {
        [Key]
        [MaxLength(36)]
        public string exam_result_detail_id { get; set; }
        [MaxLength(36)]
        public string exam_result_id { get; set; }
        public string answer_of_user { get; set; }
        [MaxLength(36)]
        public string question_id { get; set; }
        
        public ExamResult examResult { get; set; }
        public Question question { get; set; }
    }
}
