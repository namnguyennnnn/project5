
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;


namespace CoursesApi.Services.FileService
{   
    public class FileService: IFileService
    {
        private static string BucketName = "toeic-bucket-asp";
        private readonly StorageClient _storageClient;
        private readonly GoogleCredential _credential;
        public FileService()
        {
            string credentialPath = "credential.json";
            GoogleCredential credential = GoogleCredential.FromFile(credentialPath);
            _credential = credential;
            _storageClient = StorageClient.Create(credential);

        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string folderName = "uploads"; 

           
            string fileExtension = Path.GetExtension(file.FileName);
            string[] videoExtensions = { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv" }; 
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (videoExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
            {
                folderName = "videos";
            }
            else if (imageExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
            {
                folderName = "images";
            }
            else
            {              
                Console.WriteLine($"Lỗi: Tệp không thuộc vào danh sách video hoặc ảnh - {file.FileName}");
                return null;
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    var storageObject = new Google.Apis.Storage.v1.Data.Object
                    {
                        Bucket = BucketName,
                        Name = $"{folderName}/{uniqueFileName}"
                    };

                    using (var stream = new MemoryStream(memoryStream.ToArray()))
                    {
                        await _storageClient.UploadObjectAsync(storageObject, stream);
                      
                        string fileUri = $"https://storage.googleapis.com/{BucketName}/{storageObject.Name}";
                        return fileUri;
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Lỗi khi tải lên tệp: {ex.Message}");
                return null;
            }
        }




        public async Task<string> GetSignedUrl(string fileUri)
        {
            try
            {
                var sac = _credential.UnderlyingCredential as ServiceAccountCredential;
                var urlSigner = UrlSigner.FromServiceAccountCredential(sac);
          
                var fileName = fileUri.Replace($"https://storage.googleapis.com/{BucketName}/", "");

                var signedUrl = await urlSigner.SignAsync(BucketName, fileName, TimeSpan.FromHours(6));
                return signedUrl.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteFilesAsync(IEnumerable<string> fileUris)
        {
            try
            {
                foreach (var fileUri in fileUris)
                {
                    var fileName = fileUri.Replace($"https://storage.googleapis.com/{BucketName}/", "");
                    await _storageClient.DeleteObjectAsync(BucketName, fileName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting files: " + ex.Message, ex);
            }
        }

    }
}
