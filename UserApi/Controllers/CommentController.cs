using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.DTO;
using UserApi.Model;
using UserApi.Services.CommentService;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("get-commentByIdExercise/{exerciseId}")]
        public async Task<IActionResult> GetCommentByIdExercise([FromRoute] string exerciseId, int page)
        {
            var result = await _commentService.GetCommentsByIdExercise(exerciseId, page, 3);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("get-commentsByIdLecture/{lectureId}")]
        public async Task<IActionResult> GetCommentsByIdLecture([FromRoute] string lectureId)
        {
            var result = await _commentService.GetCommentsByIdLecture(lectureId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("get-commentByIdUser/{userId}")]
        public async Task<IActionResult> GetCommentByIdUser([FromRoute] string userId)
        {
            var result = await _commentService.GetCommentsByIdUser(userId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("get-commentByIdParent/{parentId}")]
        public async Task<IActionResult> GetCommentByIdParent([FromRoute] string parentId)
        {
            var result = await _commentService.GetCommentsByParentCommentId(parentId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentDto request)
        {
            var result = await _commentService.AddComment(request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update-comment/{commentId}")]
        public async Task<IActionResult> UpdateComment([FromRoute]string commentId, [FromBody] UpdateCommentDto request)
        {
            var result = await _commentService.UpdateComment(commentId, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete-comment/{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] string commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
