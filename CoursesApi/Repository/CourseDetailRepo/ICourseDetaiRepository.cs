using CoursesApi.DTO;

namespace CoursesApi.Repository.CourseDetailRepo
{
    public interface ICourseDetaiRepository
    {
        Task AddCourseDetailAsync(CreateCourseDetailDto courseDetailDto);
        Task AddCourseDetaislAsync(List<CreateCourseDetailDto> courseDetailDtos);
        Task<List<CreateCourseDetailDto>> GetCourseDetailsAsync();
        Task UpdateCourseDetailsAsync(List<CreateCourseDetailDto> courseDetails);
        Task<bool> DeleteCourseDetailAsync(string courseDetailId);
        Task<bool> DeleteCourseDetailsAsync(List<string> courseDetailId);

    }
}
