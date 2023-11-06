using System.ComponentModel.DataAnnotations;


namespace ExercisesApi.Model
{
    public class ExamResult
    {
        [Key]
        [MaxLength(36)]
        public string exam_result_id { get; set; }
        [MaxLength(36)]
        public string uid { get; set; }
        public string time_limit { get; set; }
        [MaxLength(36)]
        public string exercise_id { get; set; }
        [MaxLength(3)]
        public int score {  get; set; }

        public int total_score_listening {  get; set; }

        public int total_score_reading {  get; set; }

        public int total_right { get; set; }

        public int total_wrong { get; set; }
        public string date { get; set; }
        public Exercise exercise { get; set; }
        
        public List<ExamResultDetail> examResultDetails { get; set; }
    }
}
