using System.ComponentModel.DataAnnotations;

namespace ExercisesApi.DTO
{
    public class CreateExamResultDetailDto
    {
        public string exam_result_detail_id { get; set; }
        
        public string exam_result_id { get; set; }
        public string answer_of_user { get; set; }
       
        public string question_id { get; set; }
    }
}
