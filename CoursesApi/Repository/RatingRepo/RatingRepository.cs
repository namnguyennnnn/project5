using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repository.RatingRepo
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RatingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddRatingAsync(CreateRatingDto ratingDto)
        {
            var newRating = _mapper.Map<Ratings>(ratingDto);
            await _context.ratings.AddAsync(newRating);
            var course = await _context.courses.FindAsync(ratingDto.course_id);
            course.total_rating += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRatingAsync(string ratingId, string uid)
        {
            var existRating = await _context.ratings.FirstOrDefaultAsync(r => r.rating_id == ratingId && r.uid == uid);
            if (existRating != null)
            {
                _context.ratings.Remove(existRating);
                await _context.SaveChangesAsync();
                return true; 
            }
            return false;
        
        }

        public async Task<List<CreateRatingDto>> GetRatingsByCourseIdAsync(string courseId)
        {
            var listRatings = await _context.ratings.Where(r => r.course_id == courseId).ToListAsync();
            return _mapper.Map<List<CreateRatingDto>>(listRatings);
        }

        public async Task<CreateRatingDto> UpdateRatingAsync(string ratingId, string uid, CreateRatingDto ratingDto)
        {
            var existRating = await _context.ratings.FirstOrDefaultAsync(r => r.rating_id == ratingId && r.uid == uid);
            if (existRating != null)
            {
                existRating.rating_score = ratingDto.rating_score ?? existRating.rating_score;
                existRating.comment = ratingDto.comment ?? existRating.comment;
                existRating.uid = ratingDto.uid ?? existRating.uid;
                existRating.course_id = ratingDto.course_id ?? existRating.course_id;
                _context.ratings.Update(existRating);

                var course = await _context.courses.FindAsync(existRating.course_id);
                course.total_rating -= 1;
                await _context.SaveChangesAsync();
                return _mapper.Map<CreateRatingDto>(existRating);
            }
            return null;
        }
    }
}
