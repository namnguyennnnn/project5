using CoursesApi.DTO;
using CoursesApi.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
      
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
          
        }

        [HttpPost("add-course")]
        public async Task<IActionResult> CreateCourse([FromForm]CreateCourseRequestDto createCoursedto)
        {
            
            var result =  await _courseService.CreateCourse(createCoursedto);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("enroll-course/{courseId}")]
        public async Task<IActionResult> EnrollCourse([FromRoute] string courseId , string uid )
        {

            var result = await _courseService.EnrollmentCourse(uid, courseId);
            if (result == null)
            {
                return BadRequest("You're already enroll this course");
            }
            return Ok(result);
        }

        [HttpGet("get-allCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _courseService.GetCourses();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("get-courseById/{courseId}")]
        public async Task<IActionResult> GetCourseById([FromRoute] string courseId,string? uid)
        {
           
            if(uid == null)
            {
                return Ok(await _courseService.GetCourseByCourseIdWithoutUid(courseId));
            }
            var result = await _courseService.GetCourseByCourseId(courseId, uid);
            if (result == null)
            {
                return NotFound();
            }           
            return Ok(result);
        }
        [HttpGet("get-courseByIdWithoutUid/{courseId}")]
        public async Task<IActionResult> GetCourseByIdWithoutUid([FromRoute] string courseId)
        {
            var result = await _courseService.GetCourseByCourseIdWithoutUid(courseId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("get-courseExcludingEnrollment/{uid}")]
        public async Task<IActionResult> GetCourseExcludingEnrollment([FromRoute] string uid)
        {
            var result = await _courseService.GetCoursesExcludingErollment(uid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("get-coursesOfUser/{uid}")]
        public async Task<IActionResult> GetCourseOfUser([FromRoute] string uid)
        {
            var result = await _courseService.GetCoursesOfUser(uid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("update-course/{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromRoute]string courseId,[FromForm]CreateCourseRequestDto updateCourseDto)
        {
            var result = await _courseService.UpdateCourse(courseId, updateCourseDto);
            if (result == null)
            {
                return BadRequest("Please provide valid object");
            }
           
            return Ok(result);
        }
       

        [HttpDelete("delete-course")]
        public async Task<IActionResult> DeleteCourse([FromBody]List<string> courseIds)
        {
            var result = await _courseService.DeleteCourses(courseIds);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
