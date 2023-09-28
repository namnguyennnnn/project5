﻿namespace ExercisesApi.Services.FileService
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile File);
        Task<bool> DeleteFiles(List<string> filePath);
        Task<List<string>> SaveMultipleFiles(List<IFormFile> files);
    }
}
