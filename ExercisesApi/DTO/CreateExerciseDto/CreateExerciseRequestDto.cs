
namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateExerciseRequestDto
    {
        public string? category_detail_id { get; set; }
        public string? title_of_exercise { get; set; }
        public string? exercise_description { get; set; }
        public List<CreateQuestionDto>? questionDtos { get; set; } 
        public List<CreateImageDto>? imageDto { get; set; }
        public List<CreateParagraphDto>? paragraphDto { get; set; }
        public CreateAudioDto? audioDto { get; set; } 
    }
}
