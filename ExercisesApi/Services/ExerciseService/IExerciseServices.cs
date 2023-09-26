using ExercisesApi.DTO;
using ExercisesApi.DTO.examResponse;
using ExercisesApi.Model;
using Google.Protobuf;

namespace ExercisesApi.Services.ExerciseService
{
    public interface IExerciseServices
    {
        Task<StatusResponse> CreateExercise(CreateExerciseRequestDto exerciseRequestDto);
        Task<byte[]> GetAudioAsync(string url, List<string> timeRange);
        Task<StatusResponse> UpdateExercise(string exerciseId, ExerciseUpdateRequest ExerciseModel);
        Task<StatusResponse> DeleteExercise(string exerciseId);
        Task<ExamResponse> GetExamAsync(string exeriseId, List<int>? part = null);
        Task<List<ExerciseInfo>> GetListExercise(string categoryDetailId);
    }
}

