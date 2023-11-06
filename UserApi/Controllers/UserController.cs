using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using UserApi.DTO;
using UserApi.Services.UserService;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("get-user/{uid}")]
        public async Task<IActionResult> GetUser([FromRoute] string uid)
        {
            var result = await _userService.GetUserById(uid);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("get-examResultOfUser/{uid}")]
        public async Task<IActionResult> GetExamResultOfUser([FromRoute] string uid)
        {
            var result = await _userService.GetExamResultsByUserId(uid);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("get-examResultOfUserFromTimeRange/{uid}")]
        public async Task<IActionResult> GetExamResultOfUserFromTimeRange([FromRoute] string uid, string from, string? to )
        {
            var result = await _userService.GetExamResultsFromTimeRangeByUserId(uid, from, to);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("get-examResultById/{examResultId}")]
        public async Task<IActionResult> GetExamResultById([FromRoute] string examResultId)
        {
            var result = await _userService.GetExamResultsById(examResultId);
            if (result == null)
            {
                return Ok(null);
            }
            return Ok(result);
        }
        [HttpGet("get-examResultByExerciseIdAndUid/{exerciseId}")]
        public async Task<IActionResult> GetExamResultById([FromRoute] string exerciseId , string uid)
        {
            var result = await _userService.GetExamResultsByExerciseIdAndUid(exerciseId, uid);
            if (result == null)
            {
                return Ok(null);
            }
            return Ok(result);
        }
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("update-user/{uid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string uid, [FromForm] UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateUser(uid, updateUserDto);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("delete-user/{uid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string uid)
        {
            var result = await _userService.DeleteUser(uid);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("delete-examResultOfUser/{examResultId}")]
        public async Task<IActionResult> DeleteExamResultOfUser([FromRoute] string examResultId)
        {
            var result = await _userService.DeleteExamResult(examResultId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("delete-examResultsOfUser")]
        public async Task<IActionResult> DeleteExamResultsOfUser([FromBody] List<string> examResultId)
        {
            var result = await _userService.DeleteExamResults(examResultId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
