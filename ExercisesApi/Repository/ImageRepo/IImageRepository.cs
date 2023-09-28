using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ImageRepo
{
    public interface IImageRepository
    {
        Task AddImageAsync(Image image);
        Task<Image> GetImageByQuestionIdAsync(string questionId);
        Task UpdateImagesAsync(List<UpdateImageDto> updateImageDtos);
        Task DeleteImageAsync(string questionId);
        Task AddImagesAsync(List<Image> images);
    }
}
