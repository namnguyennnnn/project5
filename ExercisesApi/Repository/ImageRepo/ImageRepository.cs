using ExercisesApi.Data;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.ImageRepo
{
    public class ImageRepository: IImageRepository
    {
        private readonly DataContext _context;
        public ImageRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task AddImageAsync(Image image)
        {
            _context.images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task<Image> GetImageByQuestionIdAsync(string questionId)
        {
            return await _context.images.FirstOrDefaultAsync(img => img.question_id == questionId);
        }
       

        public async Task UpdateImageAsync(string questionId, Image updatedImageInfo)
        {
            var imageToUpdate =  _context.images.FirstOrDefault(img => img.question_id == questionId);
            if (imageToUpdate != null)
            {
                // Cập nhật thông tin của imageToUpdate
                imageToUpdate.image_url = updatedImageInfo.image_url;
                // Cập nhật các trường khác nếu cần

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteImageAsync(string questionId)
        {
            var imageToDelete = _context.images.FirstOrDefault(i => i.question_id == questionId);
            if (imageToDelete != null)
            {
                _context.images.Remove(imageToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
