using DocumentFormat.OpenXml.Vml;
using ExercisesApi.Model;
using ExercisesApi.Repository.ParagraphRepo;
using ExercisesApi.Services.FileService;

namespace ExercisesApi.Services.ParagraphService
{
    public class ParagraphService:IParagraphService
    {
        private readonly IParagraphRepository _paragraphRepository;
        private readonly IFileService _fileService;
        public ParagraphService(IParagraphRepository paragraphRepository, IFileService fileService)
        {
            _paragraphRepository = paragraphRepository;
            _fileService = fileService;
        }

        public async Task<Paragraph> CreateParagraph(IFormFile url, string questionId)
        {
            var filePath = await _fileService.UploadFileAsync(url);
            return new Paragraph
            {
                paragraph_id = Guid.NewGuid().ToString(),
                paragraph_url = filePath,
                question_id = questionId
            };
        }

        public async Task<Paragraph> CreateParagraphByData(byte[] paragraphData, string questionId)
        {
            var filePath = await _fileService.UploadImageByDataAsync(paragraphData);
            return new Paragraph
            {
                paragraph_id = Guid.NewGuid().ToString(),
                paragraph_url = filePath,
                question_id = questionId
            };
        }
    }
}
