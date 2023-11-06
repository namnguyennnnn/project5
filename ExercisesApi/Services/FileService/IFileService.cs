namespace ExercisesApi.Services.FileService
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<string> UploadAudioByDataAsync(byte[] audioData);
        Task<string> UploadImageByDataAsync(byte[] imageData);
        Task<string> GetSignedUrl(string fileName);
        Task DeleteFilesAsync(IEnumerable<string> fileUris);
    }
}
