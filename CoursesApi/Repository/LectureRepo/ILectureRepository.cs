using CoursesApi.DTO;

namespace CoursesApi.Repository.LectureRepo
{
    public interface ILectureRepository
    {
        Task AddLectureAsync(CreateLectureDto createLectureDto);
        Task AddLecturesAsync(List<CreateLectureDto> createLectureDtos);
        Task<CreateLectureDto> GetLectureByIdAsync(string lectureId);
        Task<List<CreateLectureDto>> GetLecturesByCourseIdAsync(string courseId);
        Task UpdateLectureAsync(List<CreateLectureDto> lectureDtos);
        Task<bool> DeleteLectureAsync(string lectureId);
    }
}
