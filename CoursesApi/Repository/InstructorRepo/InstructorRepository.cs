using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repository.InstructorRepo
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InstructorRepository(DataContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task AddInstructorAsync(CreateInstructorDto createInstructorDto)
        {
            var newInstructor = _mapper.Map<Instructors>(createInstructorDto);
            await _context.instructors.AddAsync(newInstructor);
            await _context.SaveChangesAsync();
        }


        public async Task<CreateInstructorDto> GetInstructorByIdAsync(string instructorId)
        {
            var instructor = await _context.instructors
               .Include(i => i.course) 
               .FirstOrDefaultAsync(i => i.instructor_id == instructorId);
            
            var instructorinfo = _mapper.Map<CreateInstructorDto>(instructor);
            var courses = _mapper.Map<List<CreateCourseDto>>(instructor.course);
            instructorinfo.courseDtos = courses;
            return instructorinfo;
        }

        public async Task<List<CreateInstructorDto>> GetInstructorsAsync()
        {
            var listInstructors = await _context.instructors.ToListAsync();
            return _mapper.Map<List<CreateInstructorDto>>(listInstructors);
        }

        public async Task<CreateInstructorDto> UpdateInstructorAsync(string instructorId, CreateInstructorDto createInstructorDto)
        {
            var existingInstructor = await _context.instructors.FindAsync(instructorId);
            if (existingInstructor != null) 
            {
                existingInstructor.name = createInstructorDto.name ?? existingInstructor.name;
                existingInstructor.bio = createInstructorDto.bio ?? existingInstructor.bio;
                existingInstructor.image_url = createInstructorDto.image_url ?? existingInstructor.image_url;
                _context.instructors.Update(existingInstructor);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<CreateInstructorDto>(existingInstructor);
        }
        public async Task<bool> DeleteInstructorAsync(string instructorId)
        {
            var existingInstructor = await _context.instructors.FindAsync(instructorId);
            if (existingInstructor != null)
            {
                 _context.instructors.Remove(existingInstructor);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<string>> DeleteInstructorsAsync(List<string> instructorIds)
        {
            var deletedUrls = new List<string>();

            var instructorsToDelete = await _context.instructors
                .Include(i => i.course)
                 .ThenInclude(c => c.courseDetails)
                 .ThenInclude (cd => cd.lectures)
                .Where(i => instructorIds.Contains(i.instructor_id))
                .ToListAsync();

            if (instructorsToDelete.Count != 0)
            {
                deletedUrls.AddRange(instructorsToDelete.Select(i => i.image_url));

                var coursesWithInstructors = instructorsToDelete.SelectMany(i => i.course).ToList();
                deletedUrls.AddRange(coursesWithInstructors.Select(c => c.course_image_url));

                var lecturesInCourses = coursesWithInstructors.SelectMany(c => c.courseDetails.SelectMany(cd => cd.lectures)).ToList();
                deletedUrls.AddRange(lecturesInCourses.Select(lecture => lecture.video_url));

                _context.instructors.RemoveRange(instructorsToDelete);
                await _context.SaveChangesAsync();
            }

            return deletedUrls;
        }


    }
}
