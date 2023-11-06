using ExercisesApi.DTO.examResponse;

namespace ExercisesApi.DTO.GetInfoExerciseToUpdateDto
{
    public class GetExerciseToUpdateDto
    {     
        public string? category_detail_id { get; set; }
        public string? title_of_exercise { get; set; }
        public string? exercise_description { get; set; }      
        public List<GetQuestionToUpdateDto>? questionDtos { get; set; }           
        public GetAudioToUpdateDto? audioDto { get; set; }
    }
}
