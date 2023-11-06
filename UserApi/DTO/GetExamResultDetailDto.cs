
namespace UserApi.DTO
{
    public class GetExamResultDetailDto
    {
        public string? question_id { get; set; }
        public string? question_content { get; set; }
        public string? answer_of_user { get; set; }
        public string? answer_explanation {  get; set; }
        public string? corect_answer {  get; set; }
    }
}
