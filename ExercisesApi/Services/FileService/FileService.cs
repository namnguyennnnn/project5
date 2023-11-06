
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;


namespace ExercisesApi.Services.FileService
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

            string folderName = "images";

            if (Path.GetExtension(file.FileName).Equals(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                folderName = "audio";
            }

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

                    // Sử dụng storageObject.Name khi xây dựng đường dẫn
                    string fileUri = $"https://storage.googleapis.com/{BucketName}/{storageObject.Name}";
                    return fileUri;
                }
            }
        }

        public async Task<string> UploadImageByDataAsync(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return null;
            }

            string uniqueFileName = $"{Guid.NewGuid()}.jpg"; // Tạo một tên tệp ngẫu nhiên với phần mở rộng .jpg (hoặc .png, .jpeg, tùy bạn)
            string folderName = "images";

            using (var memoryStream = new MemoryStream(imageData))
            {
                var storageObject = new Google.Apis.Storage.v1.Data.Object
                {
                    Bucket = BucketName,
                    Name = $"{folderName}/{uniqueFileName}"
                };

                await _storageClient.UploadObjectAsync(storageObject, memoryStream);

                // Sử dụng storageObject.Name khi xây dựng đường dẫn
                string fileUri = $"https://storage.googleapis.com/{BucketName}/{storageObject.Name}";
                return fileUri;
            }
        }

        public async Task<string> UploadAudioByDataAsync(byte[] audioData)
        {
            if (audioData == null || audioData.Length == 0)
            {
                return null;
            }

            string uniqueFileName = $"{Guid.NewGuid()}.mp3"; // Tạo một tên tệp ngẫu nhiên với phần mở rộng .mp3
            string folderName = "audio";

            using (var memoryStream = new MemoryStream(audioData))
            {
                var storageObject = new Google.Apis.Storage.v1.Data.Object
                {
                    Bucket = BucketName,
                    Name = $"{folderName}/{uniqueFileName}"
                };

                await _storageClient.UploadObjectAsync(storageObject, memoryStream);

                // Sử dụng storageObject.Name khi xây dựng đường dẫn
                string fileUri = $"https://storage.googleapis.com/{BucketName}/{storageObject.Name}";
                return fileUri;
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
