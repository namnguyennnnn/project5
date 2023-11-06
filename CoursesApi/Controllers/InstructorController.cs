using CoursesApi.DTO;
using CoursesApi.Services.InstructorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("add-instructor")]
        public async Task<IActionResult> CreateInstructor([FromForm] CreateInstructorDto instructorDto)
        {
            var result = await _instructorService.CreateInstructor(instructorDto);
            if (result.StatusCode == 400 || result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("get-instructors")]
        public async Task<IActionResult> GetInstructor()
        {
            var result = await _instructorService.GetInstructors();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("get-instructorById/{instructorId}")]
        public async Task<IActionResult> GetInstructorById([FromRoute] string instructorId)
        {
            var result = await _instructorService.GetInstructorById(instructorId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPatch("update-instructor/{instructorId}")]
        public async Task<IActionResult> UpdateInstructor([FromRoute] string instructorId,[FromForm] CreateInstructorDto instructorDto)
        {
            var result = await _instructorService.UpdateInstructor(instructorId,instructorDto);
            if (result ==null)
            {
                return NotFound("Instructor not found");
            }
            return Ok(result);
        }
        [HttpDelete("delete-instructors")]
        public async Task<IActionResult> DeleteInstructor( [FromBody] List<string> instructorIds)
        {
            var result = await _instructorService.DeleteInstructor(instructorIds);
            if (result.StatusCode == 400 || result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
