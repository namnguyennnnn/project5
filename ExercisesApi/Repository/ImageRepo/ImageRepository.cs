using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.CreateExerciseDto;
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


        public async Task UpdateImagesAsync(List<CreateImageDto> updateImageDtos)
        {
            foreach (var updateImage in updateImageDtos)
            {
                var existingImage = await _context.images.FirstOrDefaultAsync(i => i.image_id == updateImage.image_id);

                if (existingImage != null)
                {
                    existingImage.image_url = updateImage.image_url?? existingImage.image_url;
                    existingImage.question_id = updateImage.question_id ?? existingImage.question_id;
                    _context.images.Update(existingImage);
                }
            }
            await _context.SaveChangesAsync();
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

        public async Task AddImagesAsync(List<Image> images)
        {
            _context.images.AddRange(images);
            await _context.SaveChangesAsync();
        }
    }
}
