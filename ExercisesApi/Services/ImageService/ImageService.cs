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
            var filePath = await _fileService.SaveFile(url);
            return  new Image
            {
                image_id = Guid.NewGuid().ToString(),
                image_url = filePath,
                question_id = questionId
            };
        }
        public async Task CreateImages(List<IFormFile> urls, List<string> questionIds)
        {
            if (urls.Count != questionIds.Count)
            {
                throw new ArgumentException("The number of urls must match the number of questionIds.");
            }

            var fileUrls = await _fileService.SaveMultipleFiles(urls);

            var newImages = fileUrls.Select((url, index) => new Image
            {
                image_id = Guid.NewGuid().ToString(),
                image_url = url,
                question_id = questionIds[index]
            }).ToList();

            await _imageRepository.AddImagesAsync(newImages);
        }
    }
}
