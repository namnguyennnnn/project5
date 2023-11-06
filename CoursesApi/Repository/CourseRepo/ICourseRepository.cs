using CoursesApi.DTO;

namespace CoursesApi.Repository.CourseRepo
{
    public interface ICourseRepository
    {
        Task AddCoursAsync(CreateCourseDto course);
        Task<List<CreateCourseDto>> GetCoursesAsync();
        Task<GetCourseDto> GetCourseByIdAsync(string courseId  );
       
        Task<GetCourseDto> GetCourseByIdForUpdateAsync(string courseId);
        Task<List<CreateCourseDto>> GetCoursesExcludingErollmentAsync(string uid);
        Task<List<CreateCourseDto>> GetCoursesOfUserAsync(string uid);
        Task<CreateCourseDto> UpdateCoursAsync(string courseId, CreateCourseDto createCourseDto);
        Task<bool> DeleteCoursesAsync(string courseId);
        Task<List<string>> DeleteCoursesAsync(List<string> courseIds);

    }
}
