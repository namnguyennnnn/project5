using ExercisesApi.DTO;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.examResponse;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;
using Google.Protobuf;

namespace ExercisesApi.Services.ExerciseService
{
    public interface IExerciseServices
    {
        Task<StatusResponse> CreateExercise(CreateExerciseRequestDto exerciseRequestDto);
        Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId);
        Task<ExamResponse> GetExamAsync(string exeriseId, List<int>? part = null);
        Task<List<ExerciseInfo>> GetExercisesByCategoryDetail(string categoryDetailId);
        Task<List<ExerciseInfo>> GetExercises();
        Task<byte[]> GetAudioAsync(string url, List<string> timeRange);
        Task<GetExerciseToUpdateDto> UpdateExamAsync(string exerciseId, UpdateExerciseRequestDto requestDto);
        Task<StatusResponse> DeleteExercise(string exerciseId);
    }
}

