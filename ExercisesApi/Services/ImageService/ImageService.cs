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

        public async Task<Image> CreateImage(IFormFile url,string questionId)
        {
            var filePath = await _fileService.UploadFileAsync(url);
            return  new Image
            {
                image_id = Guid.NewGuid().ToString(),
                image_url = filePath,
                question_id = questionId
            };
        }
        public async Task<Image> CreateImageByData(byte[] imageData, string questionId)
        {
            var filePath = await _fileService.UploadImageByDataAsync(imageData);
            return new Image
            {
                image_id = Guid.NewGuid().ToString(),
                image_url = filePath,
                question_id = questionId
            };
        }
    }
}
