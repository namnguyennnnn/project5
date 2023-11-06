using CoursesApi.DTO;
using CoursesApi.Services.RatingService;

using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpPost("add-rating")]
        public async Task<IActionResult> CreateRating([FromBody] CreateRatingDto createRatingDto)
        {

            var result = await _ratingService.CreateRating(createRatingDto);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPatch("update-rating/{ratingId}/{uid}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] string ratingId,string uid, [FromBody] CreateRatingDto createRatingDto)
        {
            var result = await _ratingService.UpdateRating(ratingId,uid, createRatingDto);
            if (result == null)
            {
                return BadRequest("Please provide valid object");
            }

            return Ok(result);
        }

        [HttpDelete("delete-rating/{ratingId}/{uid}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] string ratingId ,string uid)
        {
            var result = await _ratingService.DeteleRating(ratingId, uid);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
