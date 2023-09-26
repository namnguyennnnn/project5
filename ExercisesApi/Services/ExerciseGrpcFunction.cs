using Grpc.Core;
using ExercisesApi.Repository.ExerciseRepo;
using ExerciseManagement;
using ExercisesApi.DTO;

namespace ExercisesApi.Services
{
    public class ExerciseGrpcFunction : ExerciseManagement.ExerciseManager.ExerciseManagerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseGrpcFunction(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
      
        public override async Task<DeleteExercisesResponse> DeleteExercises(DeleteExercisesRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _exerciseRepository.DeleteExercisesByCategoryDetailIdAsync(request.CategoryDetailId);

            return await Task.FromResult(new DeleteExercisesResponse
            {
                Status = 200
            });
        }
    }
}