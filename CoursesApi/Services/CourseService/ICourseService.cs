using CoursesApi.DTO;

namespace CoursesApi.Services.CourseService
{
    public interface ICourseService
    {
        Task<GetCourseDto> CreateCourse(CreateCourseRequestDto courseDto);   
        Task<GetCourseDto> EnrollmentCourse(string uid , string courseId);             
        Task<List<CreateCourseDto>> GetCourses();
        Task<GetCourseDto> GetCourseByCourseId(string courseId, string uid);
        Task<GetCourseDto> GetCourseByCourseIdWithoutUid(string courseId);
        Task<List<CreateCourseDto>> GetCoursesOfUser(string uid);
        Task<List<CreateCourseDto>> GetCoursesExcludingErollment(string uid);
        Task<GetCourseDto> UpdateCourse(string courseId , CreateCourseRequestDto courseDto);
        Task<StatusResponse> DeleteCourses(List<string> courseId);
    }
}
