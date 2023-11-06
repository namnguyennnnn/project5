using CoursesApi.DTO;

namespace CoursesApi.Services.RatingService
{
    public interface IRatingService
    {
        Task<CreateRatingDto> CreateRating(CreateRatingDto createRatingDto);
        Task<CreateRatingDto> UpdateRating(string ratingId, string uid, CreateRatingDto updateRatingDto);
        Task<StatusResponse> DeteleRating(string ratingId, string uid);
    }
}
