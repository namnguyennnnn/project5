
using ExercisesApi.Model;

namespace ExercisesApi.Services.ImageService
{
    public interface IImageService
    {
        Task<Image> CreateImage(IFormFile url, string questionId);
        Task<Image> CreateImageByData(byte[] imageData, string questionId);
    }
}
