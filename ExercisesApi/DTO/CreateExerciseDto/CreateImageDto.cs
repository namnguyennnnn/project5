namespace ExercisesApi.DTO.CreateExerciseDto
{
    public class CreateImageDto
    {
        public int questionIndex { get; set; }
        public IFormFile imageFile { get; set; }
    }
}
