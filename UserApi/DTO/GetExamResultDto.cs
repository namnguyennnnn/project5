namespace UserApi.DTO
{
    public class GetExamResultDto
    {
        public string? exam_result_id { get; set; }
        public string? uid { get; set; }
        public string? exercise_id { get; set; }
        public string? title_of_exercise { get; set; }
        public string? time_limit { get; set; }
        public int? score { get; set; }

        public int? total_score_listening { get; set; }

        public int? total_score_reading { get; set; }

        public int? total_right { get; set; }

        public int? total_wrong { get; set; }
        public string? date { get; set; }
        public List<GetExamResultDetailDto>? exam_result_details { get; set; }
    }
}
