namespace CoursesApi.DTO
{
    public class CreateCourseRequestDto
    {
        public CreateCourseDto? CourseDto {  get; set; }
        public List<CreateCourseDetailDto>? CourseDetailDtos { get; set; }      
    }
}
