namespace ExercisesApi.Services.ImageService
{
    public interface IImageService
    {
        Task CreateImage(IFormFile url, string questionId);
    }
}
