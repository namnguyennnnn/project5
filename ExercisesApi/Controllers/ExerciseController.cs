


using ExercisesApi.DTO;
using ExercisesApi.DTO.CreateExerciseDto;

using ExercisesApi.Services.ExerciseService;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

using OfficeOpenXml.Drawing;


namespace ExercisesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseServices _exerciseServices;

        public ExerciseController(IExerciseServices exerciseServices)
        {
            _exerciseServices = exerciseServices;

        }
        [HttpGet("get-exercises/{categoryDetalId}")]
        public async Task<IActionResult> GetExerciseByCategoryId([FromRoute] string categoryDetalId)
        {
            var results = await _exerciseServices.GetExercisesByCategoryDetail(categoryDetalId);

            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("get-exercises/")]
        public async Task<IActionResult> GetExercise()
        {
            var rs = await _exerciseServices.GetExercises();
            return Ok(rs);
        }
        [HttpGet("get-exercisesByIdExercise/{exerciseId}")]
        public async Task<IActionResult> GetExerciseById([FromRoute] string exerciseId)
        {
            var rs = await _exerciseServices.GetExerciseByIdForUpdateAsync(exerciseId);
            return Ok(rs);
        }
        [HttpGet("get-exam/{exerciseId}")]
        public async Task<IActionResult> GetExam([FromRoute] string exerciseId, [FromQuery] List<int>? parts = null)
        {

            var results = await _exerciseServices.GetExamAsync(exerciseId, parts);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);

        }
        [HttpPost("submit-exam/{exerciseId}")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> CreateExercise([FromRoute] string exerciseId, string uid, string timeLimit, [FromBody] List<AnswerOfUserDto> answersOfUser)
        {

            if (exerciseId == null || uid == null || timeLimit == null || answersOfUser.Any(i => i == null))
            {
                return BadRequest("Please provide non null value");
            }
            var results = await _exerciseServices.GradeTheExam(exerciseId, uid, answersOfUser, timeLimit);
            return Ok(results);

        }

        [HttpPost("add-exercise")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> CreateExercise([FromForm] CreateExerciseRequestDto exerciseRequestDto)
        {

            if (exerciseRequestDto == null)
            {
                return BadRequest();
            }
            var results = await _exerciseServices.CreateExercise(exerciseRequestDto);
            return Ok(results);

        }

        [HttpPost("add-exerciseByExcel")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> CreateExerciseByExcel(IFormFile excelFile, IFormFile audioFile)
        {

            if (excelFile == null || audioFile == null)
            {
                return BadRequest("Please submit valid file");
            }
            var results = await _exerciseServices.CreateExerciseByExcelFile(excelFile, audioFile);
            return Ok(results);

        }

        [HttpPost("get-fileAudio")]
        public async Task<IActionResult> GetAudio([FromBody] GetAudioRequest req)
        {
            var results = await _exerciseServices.GetAudioAsync(req.audioUrl, req.timeRange);
            return File(results, "audio/mpeg", "audio.mp3");
        }

        [HttpPut("update-exercise/{exerciseId}")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> UpdateExercise([FromRoute] string exerciseId, [FromForm] CreateExerciseRequestDto req)
        {
            var results = await _exerciseServices.UpdateExamAsync(exerciseId, req);
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(results);
        }

        [HttpDelete("delete-exercise/{exerciseId}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] string exerciseId)
        {
            var results = await _exerciseServices.DeleteExercise(exerciseId);
            return Ok(results);
        }

        [HttpDelete("delete-exercise")]
        public async Task<IActionResult> DeleteExercise([FromBody] List<string> exerciseId)
        {
            var results = await _exerciseServices.DeleteExercises(exerciseId);
            return Ok(results);
        }


    }

}




