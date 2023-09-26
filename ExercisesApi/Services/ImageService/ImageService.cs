using ExercisesApi.Model;
using ExercisesApi.Repository.ImageRepo;
using ExercisesApi.Services.FileService;

namespace ExercisesApi.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileService _fileService;
        public ImageService(IImageRepository imageRepository, IFileService fileService)
        {
            _imageRepository = imageRepository;
            _fileService = fileService;
        }

        public async Task CreateImage(IFormFile url,string questionId)
        {
            var filePath = await _fileService.SaveFile(url);
            var newImage = new Image
            {
                image_id = Guid.NewGuid().ToString(),
                image_url = filePath,
                question_id = questionId
            };
            await _imageRepository.AddImageAsync(newImage);
        }
    }
}
