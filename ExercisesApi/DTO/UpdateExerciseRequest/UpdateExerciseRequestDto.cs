using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;

namespace ExercisesApi.DTO.UpdateExerciseRequest
{
    public class UpdateExerciseRequestDto
    {
        public ExerciseInfo? exerciseToUpdateDto { get; set; } = null;
        public UpdateAudioDto? audioToUpdateDto { get; set; } = null;
        public List<UpdateQuestionDto>? questionToUpdateDto { get; set; } = null;
        public List<GetAnswerToUpdateDto>? answerToUpdateDto { get; set; } = null;
        public List<UpdateImageDto>? imageToUpdateDto { get; set; } = null;
        public List<UpdateParagraphDto>? paragraphToUpdateDto { get; set; } = null;
    }
}
