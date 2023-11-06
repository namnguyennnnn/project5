using ExercisesApi.DTO;

namespace ExercisesApi.Repository.ExamResultDetailRepo
{
    public interface IExamResultDetailRepository
    {
        Task AddExamResultDetailsAsync(List<CreateExamResultDetailDto> createExamResultsDetailDto);
    }
}
