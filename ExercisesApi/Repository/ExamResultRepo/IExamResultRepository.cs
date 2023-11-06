using ExercisesApi.DTO;

namespace ExercisesApi.Repository.ExamResultRepo
{
    public interface IExamResultRepository
    {
        Task<List<CreateExamResultDto>> GetExamResultsByUserIdAsync(string uid);
        Task<GetExamResultDto> GetExamResultsByExerciseIdAndUidAsync(string exerciseId ,string uid);
        Task<List<GetAverageExamResultPerDayDto>> GetExamResultsByUserIdFromTimeRangeAsync(string uid, string fromDate, string toDate);       
        Task<GetExamResultDto> GetExamResultByIdAsync(string examResultId);
        Task AddExamResultAsync(CreateExamResultDto createExamResultDto);
        Task<bool> DeleteExamResultAsync(string examResultId);
        Task<bool> DeleteExamResultsAsync(List<string> examResultIds);
    }
}
