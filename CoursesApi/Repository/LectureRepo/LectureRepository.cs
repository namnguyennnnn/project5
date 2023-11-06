using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repository.LectureRepo
{
    public class LectureRepository : ILectureRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LectureRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public async Task AddLectureAsync(CreateLectureDto createLectureDto)
        {
            var newLecture = _mapper.Map<Lectures>(createLectureDto);
            await _context.lectures.AddAsync(newLecture);
            await _context.SaveChangesAsync();
        }

        public async Task AddLecturesAsync(List<CreateLectureDto> createLectureDtos)
        {
            var newLectures = _mapper.Map<List<Lectures>>(createLectureDtos);
            await _context.lectures.AddRangeAsync(newLectures);
            await _context.SaveChangesAsync();
        }

        public async Task<CreateLectureDto> GetLectureByIdAsync(string lectureId)
        {
            var lecture = await _context.lectures.FindAsync(lectureId);
            return _mapper.Map<CreateLectureDto>(lecture);
        }

        public async Task<List<CreateLectureDto>> GetLecturesByCourseIdAsync(string courseId)
        {
            var listLectures = await _context.lectures.ToListAsync();
            return _mapper.Map<List<CreateLectureDto>>(listLectures);
        }

        public async Task UpdateLectureAsync(List<CreateLectureDto> lectureDtos)
        {
            foreach (var updateLecture in lectureDtos)
            {
                var existLecture = await _context.lectures.FirstOrDefaultAsync(l => l.lecture_id == updateLecture.lecture_id);
                if (existLecture != null)
                {
                    existLecture.lecture_index = updateLecture.lecture_index ?? existLecture.lecture_index;
                    existLecture.lecture_title = updateLecture.lecture_title ?? existLecture.lecture_title;
                    existLecture.content = updateLecture.lecture_title ?? existLecture.content;
                    existLecture.video_url = updateLecture.video_url ?? existLecture.video_url;
                    existLecture.course_detail_id = updateLecture.course_detail_id ?? existLecture.course_detail_id;
                    _context.lectures.Update(existLecture);

                }
            }
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteLectureAsync(string lectureId)
        {
            var existLecture = await _context.lectures.FindAsync(lectureId);

            if(existLecture != null)
            {
                _context.lectures.Remove(existLecture);
                return true;
            }
            return false;

        }

        
    }
}
