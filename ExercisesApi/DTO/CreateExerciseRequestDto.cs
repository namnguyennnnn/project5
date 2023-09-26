using ExercisesApi.DTO.examResponse;

namespace ExercisesApi.DTO
{
    public class CreateExerciseRequestDto
    {
        public string category_detail_id { get; set; }
        public string title_of_exercise { get; set; }
        public string exercise_description { get; set; }
        public List<CreateQuestionDto> questionDtos { get; set; }
        public List<CreateAnswerDto> answerDtos { get; set; }
        public List<IFormFile> image_url { get; set; }
        public CreateAudioDto audioDto { get; set; }

    }
}
