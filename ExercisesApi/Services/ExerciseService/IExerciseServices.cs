using UserManagement;
using ExercisesApi.DTO;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.examResponse;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;

namespace ExercisesApi.Services.ExerciseService
{
    public interface IExerciseServices
    {
        Task<StatusResponse> CreateExercise(CreateExerciseRequestDto exerciseRequestDto);
        Task<StatusResponse> CreateExerciseByExcelFile(IFormFile excelFile, IFormFile audiofile);
        Task<GetExamResultDto> GradeTheExam(string exerciseId, string uid, List<AnswerOfUserDto> answersOfUser, string timeLimit);
        Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId);
        Task<ExamResponse> GetExamAsync(string exeriseId, List<int>? part = null);
        Task<GetTotalCommentsResponse> GetExercisesByCategoryDetail(string categoryDetailId);
        Task<GetTotalCommentsResponse> GetExercises();
        Task<byte[]> GetAudioAsync(string url, List<string> timeRange);
        Task<GetExerciseToUpdateDto> UpdateExamAsync(string exerciseId, CreateExerciseRequestDto requestDto);
        Task<StatusResponse> DeleteExercise(string exerciseId);
        Task<StatusResponse> DeleteExercises(List<string> exerciseId);
       

    }
}

