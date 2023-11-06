using CoursesApi.DTO;

namespace CoursesApi.Repository.InstructorRepo
{
    public interface IInstructorRepository
    {
        Task AddInstructorAsync(CreateInstructorDto createInstructorDto);
        Task<CreateInstructorDto> GetInstructorByIdAsync(string instructorId);
        Task<List<CreateInstructorDto>> GetInstructorsAsync();
        Task<CreateInstructorDto> UpdateInstructorAsync(string instructorId , CreateInstructorDto createInstructorDto);
        Task<bool> DeleteInstructorAsync(string instructorId);
        Task<List<string>> DeleteInstructorsAsync(List<string> instructorIds);
    }
}
