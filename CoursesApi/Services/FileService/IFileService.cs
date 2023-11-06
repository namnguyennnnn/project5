namespace CoursesApi.Services.FileService
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);     
        Task<string> GetSignedUrl(string fileName);
        Task DeleteFilesAsync(IEnumerable<string> fileUris);
    }
}
