

namespace ExercisesApi.DTO.GetDataExerciseFromExcelDto
{
    public class ExcelCreateExerciseRequestDto
    {
        public ExcelExerciseDto? exercisedto { get; set; }
        public List<ExcelQuestionDto>? questionDtos { get; set; }
        public ExcelAudioDto? audiodto { get; set; }
        public List<ExcelImagesDto> imagesDatas { get; set; }
        public List<ExcelParagraphDto> paragraphsDatas { get; set; }
    }
}
