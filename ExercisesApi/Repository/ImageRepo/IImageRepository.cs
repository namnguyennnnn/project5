using ExercisesApi.Model;

namespace ExercisesApi.Repository.ImageRepo
{
    public interface IImageRepository
    {
        Task AddImageAsync(Image image);
        Task<Image> GetImageByQuestionIdAsync(string questionId);
        Task UpdateImageAsync(string questionId, Image updatedImageInfo);
        Task DeleteImageAsync(string questionId);

    }
}
