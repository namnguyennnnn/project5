namespace UserApi.DTO
{
    public class GetAverageExamResultPerDayDto
    {
        public string? date { get; set; }
        public int countExamReultPerDate { get; set; }
        public int averageScorePerDate { get; set; }
    }
}
