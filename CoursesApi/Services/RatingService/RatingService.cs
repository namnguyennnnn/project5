using CoursesApi.DTO;
using CoursesApi.Repository.CourseRepo;
using CoursesApi.Repository.RatingRepo;

namespace CoursesApi.Services.RatingService
{
    public class RatingService:IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICourseRepository _courseRepository;
        public RatingService(IRatingRepository ratingRepository, ICourseRepository courseRepository )
        {
            _ratingRepository = ratingRepository;
            _courseRepository = courseRepository;
        }
        public async Task<CreateRatingDto> CreateRating(CreateRatingDto createRatingDto)
        {
            if (createRatingDto == null)
            {
                throw new Exception("Please provide valid data");
            }
            var newRating = new CreateRatingDto
            {
                rating_id = Guid.NewGuid().ToString(),
                uid = createRatingDto.uid,
                rating_score = createRatingDto.rating_score,
                comment = createRatingDto.comment,
                course_id = createRatingDto.course_id,
            };
            await _ratingRepository.AddRatingAsync(newRating);
            
            return new CreateRatingDto
            {
                rating_id = newRating.rating_id,
                uid = createRatingDto.uid,
                rating_score = createRatingDto.rating_score,
                comment = createRatingDto.comment,
                course_id = createRatingDto.course_id,
                avartar = createRatingDto.avartar ?? null,
                user_name = createRatingDto.user_name ?? null
            };
        }

        public async Task<StatusResponse> DeteleRating(string ratingId,string uid)
        {
            if (string.IsNullOrEmpty(ratingId))
            {
                throw new Exception("Please provide valid data");
            }
            if(await _ratingRepository.DeleteRatingAsync(ratingId, uid) == true)
            {                
                return new StatusResponse { StatusCode = 200, StatusDetail = "Delete Sucess" };
            }
            return null;
        }

        public async Task<CreateRatingDto> UpdateRating(string ratingId, string uid, CreateRatingDto updateRatingDto)
        {
            if (updateRatingDto == null)
            {
                throw new Exception("Please provide valid data");
            }
            var newRating = new CreateRatingDto
            {
                rating_score = updateRatingDto.rating_score ?? null,
                comment = updateRatingDto.comment
            };
            var rating = await _ratingRepository.UpdateRatingAsync(ratingId, uid, newRating);
            return new CreateRatingDto
            {
                rating_id = rating.rating_id,
                uid = rating.uid,
                rating_score = rating.rating_score,
                comment = rating.comment,
                course_id = rating.course_id,
                avartar = updateRatingDto.avartar ?? null,
                user_name = updateRatingDto.user_name ?? null
            };
        }
    }
}
