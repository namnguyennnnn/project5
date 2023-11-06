using CoursesApi.DTO;

namespace CoursesApi.Repository.EnrollmentRepo
{
    public interface IEnrollmentRepository
    {
        Task<bool> AddEnrollmentAsync(CreateEnrollmentDto enrollmentdto);
        Task<bool> IsEnrollAsync(string courseId,string uid);
    }
}
