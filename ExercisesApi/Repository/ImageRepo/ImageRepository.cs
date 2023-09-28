using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;


namespace ExercisesApi.Repository.ImageRepo
{
    public class ImageRepository: IImageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ImageRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
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


        public async Task UpdateImagesAsync(List<UpdateImageDto> updateImageDtos)
        {
            foreach (var updateImage in updateImageDtos)
            {
                var existingImage = await _context.images.FirstOrDefaultAsync(i => i.image_id == updateImage.image_id);

                if (existingImage != null)
                {
                    existingImage.image_url = updateImage.image_url;
                    existingImage.question_id = updateImage.question_id;
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
