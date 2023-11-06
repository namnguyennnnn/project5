using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace UserApi.Services.FileService
{   
    public class FileService: IFileService
    {
        private readonly Cloudinary _cloudinary;

        public FileService(IConfiguration configuration)
        {
            string cloudName = configuration["CloudinarySettings:CloudName"];
            string apiKey = configuration["CloudinarySettings:ApiKey"];
            string apiSecret = configuration["CloudinarySettings:ApiSecret"];

            Account account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<bool> DeleteFiles(List<string> filePath)
        {
            foreach (var url in filePath)
            {
                string publicId = GetPublicIdFromUrl(url);
                var deletionResult = await _cloudinary.DeleteResourcesByPrefixAsync(publicId);

                if (deletionResult.Deleted.Count == 0)
                {
                    Console.WriteLine($"Xóa tài nguyên không thành công: {url}");
                    return false;
                }
                else
                {
                    Console.WriteLine($"Đã xóa tài nguyên: {url}");
                }
            }

            return true;
        }

        public async Task<string> SaveFile(IFormFile File)
        {
            if (File == null || File.Length == 0)
            {
                // Xử lý lỗi khi tệp không hợp lệ.
                return "Tệp không hợp lệ.";
            }

            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(File.FileName)}";
            var folderName = "images";        
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await File.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    var uploadParams = new RawUploadParams
                    {
                        File = new FileDescription(uniqueFileName, memoryStream),
                        PublicId = $"{folderName}/{uniqueFileName}"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    return uploadResult.SecureUri.ToString();
                }
            }
            catch (Exception ex)
            {
                
                return $"Lỗi khi tải lên: {ex.Message}";
            }
            finally
            {
                
                File = null;
            }
        }

        public async Task<string> SaveFileByDataFile(byte[] imageData, string fileName)
        {
            if (imageData == null || imageData.Length == 0)
            {
                // Xử lý lỗi khi dữ liệu không hợp lệ.
                return "Dữ liệu không hợp lệ.";
            }
            string uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            var folderName = "images";
            try
            {
                using (var memoryStream = new MemoryStream(imageData))
                {
                    var uploadParams = new RawUploadParams
                    {
                        File = new FileDescription(uniqueFileName, memoryStream),
                        PublicId = $"{folderName}/{uniqueFileName}"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    return uploadResult.SecureUri.ToString();
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi khi tải lên: {ex.Message}";
            }
        }

        public async Task<List<string>> SaveMultipleFiles(List<IFormFile> files)
        {
            var fileUrls = new List<string>();

            foreach (var file in files)
            {
                var result = await SaveFile(file);
                if (!string.IsNullOrEmpty(result))
                {
                    fileUrls.Add(result);
                }
            }

            return fileUrls;
        }

        private string GetPublicIdFromUrl(string url)
        {
            // Trích xuất public ID từ URL Cloudinary
            Uri uri = new Uri(url);
            string publicId = uri.Segments.Last().Split('.')[0];
            return publicId;
        }
    }
}
