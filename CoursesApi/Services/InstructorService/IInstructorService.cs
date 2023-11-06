using CoursesApi.DTO;

namespace CoursesApi.Services.InstructorService
{
    public interface IInstructorService
    {
        Task<StatusResponse> CreateInstructor(CreateInstructorDto createInstructorDto);
        Task<List<CreateInstructorDto>> GetInstructors();
        Task<CreateInstructorDto> GetInstructorById(string instructorId);
        Task<CreateInstructorDto> UpdateInstructor(string instructorId,CreateInstructorDto updateInstructorDto);
        Task<StatusResponse> DeleteInstructor(List<string> instructorIds);
    }
}
