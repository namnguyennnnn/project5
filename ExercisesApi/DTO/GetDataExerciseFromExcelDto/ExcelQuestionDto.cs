
namespace ExercisesApi.DTO.GetDataExerciseFromExcelDto
{
    public class ExcelQuestionDto
    {
        public string? question_id { get; set; }
        public string? exercise_id { get; set; }

        public string? question_content { get; set; }

        public int? index { get; set; }
   
        public string? answer_explanation { get; set; }

        public string? a { get; set; }

        public string? b { get; set; }

        public string? c { get; set; }

        public string? d { get; set; }

        public string? corect_answer { get; set; }
    }
}
