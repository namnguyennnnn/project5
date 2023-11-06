using ExerciseManagement;
using UserApi.DTO;

namespace UserApi.Services.UserService
{
    public interface IUserService
    {
        Task<GetUserDto> GetUserById(string uid);
        Task<List<ExamResultDto>> GetExamResultsByUserId(string uid);
        Task<List<GetAverageExamResultPerDayDto>> GetExamResultsFromTimeRangeByUserId(string uid,string from,string to);
        Task<GetExamResultDto> GetExamResultsById(string examResultId);
        Task<GetExamResultDto> GetExamResultsByExerciseIdAndUid(string exerciseId, string uid);
        Task<List<GetUserDto>> GetUsers();
        Task<GetUserDto> UpdateUser(string uid, UpdateUserDto updateUserDto);
        Task<ResultResponse> DeleteUser(string uid);
        Task<ResultResponse> DeleteExamResult(string examResultId);
        Task<ResultResponse> DeleteExamResults(List<string> examResultId);
    }
}
