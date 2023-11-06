using CoursesApi.DTO;

namespace CoursesApi.Repository.RatingRepo
{
    public interface IRatingRepository
    {
        Task AddRatingAsync(CreateRatingDto ratingDto);
        Task<List<CreateRatingDto>> GetRatingsByCourseIdAsync(string courseId);
        Task<CreateRatingDto> UpdateRatingAsync(string ratingId, string uid, CreateRatingDto ratingDto);
        Task<bool> DeleteRatingAsync(string ratingId, string uid);
    }
}
