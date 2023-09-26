
using ExercisesApi.DTO;
using ExercisesApi.Services.ExerciseService;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseServices _exerciseServices;
        

        public ExerciseController( IExerciseServices exerciseServices)
        {
            _exerciseServices = exerciseServices;
           
        }
        [HttpGet("get-exercises/{categoryDetalId}")]
        public async Task<ActionResult> GetExerciseByCategoryId([FromRoute] string categoryDetalId)
        {
            var rs = await _exerciseServices.GetListExercise(categoryDetalId);
            return Ok(rs);
        }

        [HttpGet("get-exam/{exerciseId}")]
        public async Task<ActionResult> GetExam([FromRoute] string exerciseId, [FromQuery] List<int>? parts = null)
        {
            try
            {
                var results = await _exerciseServices.GetExamAsync(exerciseId, parts);
            
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("update-exercise/{exerciseId}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] string exerciseId , [FromForm]ExerciseUpdateRequest exerciseModel)
        {
            var results = await _exerciseServices.UpdateExercise(exerciseId, exerciseModel);
            return Ok(results);
        }

        [HttpPost("add-exercise")]
        
        public async Task<IActionResult> CreateExercise([FromForm] CreateExerciseRequestDto exerciseRequestDto )
        {
            
            if(exerciseRequestDto == null)
            {
                return BadRequest();
            }  
            var results = await _exerciseServices.CreateExercise(exerciseRequestDto);
            return Ok(results);
          
        }

        [HttpDelete("delete-exercise/{exerciseId}")]
        public async Task<IActionResult> DeleteExercise([FromRoute]string exerciseId)
        {
            var results = await _exerciseServices.DeleteExercise(exerciseId);
            return Ok(results);
        }

        [HttpPost("get-fileAudio")]
        public async Task<IActionResult> GetAudio([FromForm] GetAudioRequest req)
        {
            var results = await _exerciseServices.GetAudioAsync(req.AudioUrl,req.TimeRange);
            return File(results, "audio/mpeg", "audio.mp3");
        }

        
    }
}



