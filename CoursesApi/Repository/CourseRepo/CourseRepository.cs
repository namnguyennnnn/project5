using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;
using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;

namespace CoursesApi.Repository.CourseRepo
{
    public class CourseRepository :ICourseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; 
        public CourseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCoursAsync(CreateCourseDto course)
        {
            var newCourse = _mapper.Map<Courses>(course);
            await _context.courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<GetCourseDto> GetCourseByIdAsync(string courseId)
        {
            var course = await _context.courses
                .Include(c => c.instructor)
                .Include(c => c.courseDetails)
                    .ThenInclude(cd=> cd.lectures)
                .Include(c => c.ratings)
                .FirstOrDefaultAsync(c => c.course_id == courseId);
            course.courseDetails.OrderBy(c => c.course_detail_index).ToList();
            var instructor = _mapper.Map<CreateInstructorDto>(course.instructor);
            var ratings = _mapper.Map<List<CreateRatingDto>>(course.ratings);
            var courseDetails = new List<CreateCourseDetailDto>();
            
            foreach(var courseDetail in course.courseDetails)
            {
                var newCourdetaiInfo = new CreateCourseDetailDto
                {
                    course_detail_id = courseDetail.course_detail_id,
                    course_detail_index = courseDetail.course_detail_index,
                    course_detail_name = courseDetail.course_detail_name,
                    total_lecture = courseDetail.total_lecture,
                    course_id = courseDetail.course_id,
                    LectureDtos = _mapper.Map<List<CreateLectureDto>>(course.courseDetails.SelectMany(cd => cd.lectures)
                    .Where(lecture => lecture.course_detail_id == courseDetail.course_detail_id))
                };
                courseDetails.Add(newCourdetaiInfo);
            }
            return new GetCourseDto
            {
                course_id = course.course_id,
                course_name = course.course_name,
                course_description = course.course_description,
                course_goal = course.course_goal,
                course_price = course.course_price,
                total_rating = course.total_rating,
                average_score_rating = course.average_score_rating,
                total_member = course.total_member,
                course_image_url = course.course_image_url,
                course_created_at = course.course_created_at,
                instructor = instructor,
                courseDetailDtos = courseDetails,
                ratingDtos = ratings
            };
        }
       
        public async Task<GetCourseDto> GetCourseByIdForUpdateAsync(string courseId)
        {
            var course = await _context.courses
                .Include(c => c.instructor)
                .Include(c => c.courseDetails)     
                .ThenInclude(cd=>cd.lectures)
                .FirstOrDefaultAsync(c => c.course_id == courseId);
            course.courseDetails.OrderBy(c => c.course_detail_index).ToList();
            var instructor = _mapper.Map<CreateInstructorDto>(course.instructor);           
            var courseDetails = new List<CreateCourseDetailDto>();

            foreach (var courseDetail in course.courseDetails)
            {
                var newCourdetaiInfo = new CreateCourseDetailDto
                {
                    course_detail_id = courseDetail.course_detail_id,
                    course_detail_index = courseDetail.course_detail_index,
                    course_detail_name = courseDetail.course_detail_name,
                    total_lecture = courseDetail.total_lecture,
                    course_id = courseDetail.course_id,
                    LectureDtos = _mapper.Map<List<CreateLectureDto>>(course.courseDetails.SelectMany(cd => cd.lectures)
                    .Where(lecture => lecture.course_detail_id == courseDetail.course_detail_id))
                };
                courseDetails.Add(newCourdetaiInfo);
            }
            return new GetCourseDto
            {
                course_id = course.course_id,
                course_name = course.course_name,
                course_description = course.course_description,
                course_goal = course.course_goal,
                course_price = course.course_price,
                total_rating = course.total_rating,
                average_score_rating = course.average_score_rating,
                total_member = course.total_member,
                course_image_url = course.course_image_url,
                course_created_at = course.course_created_at,
                instructor = instructor,
                courseDetailDtos = courseDetails,
                
            };
        }

        public async Task<List<CreateCourseDto>> GetCoursesExcludingErollmentAsync(string uid)
        {
            var enrolledCourseIds = await _context.enrollments
               .Where(e => e.uid == uid)
               .Select(e => e.course_id)
               .ToListAsync();
           
            var courses = await _context.courses
                .Where(c => !enrolledCourseIds.Contains(c.course_id))
                .ToListAsync();
            return _mapper.Map<List<CreateCourseDto>>(courses);
        }

        public async Task<List<CreateCourseDto>> GetCoursesOfUserAsync(string uid)
        {
            var enrolledCourses = await _context.enrollments
            .Where(e => e.uid == uid)
            .Select(e => e.course_id)
            .ToListAsync();

            var courses = await _context.courses
                .Where(c => enrolledCourses.Contains(c.course_id))
                .ToListAsync();
            return _mapper.Map<List<CreateCourseDto>>(courses);
        }

        public async Task<List<CreateCourseDto>> GetCoursesAsync()
        {
            var courses = await _context.courses.ToListAsync();
            return _mapper.Map<List<CreateCourseDto>>(courses);
        }

        public async Task<CreateCourseDto> UpdateCoursAsync(string courseId, CreateCourseDto updateCourseDto)
        {
            var existingCourse = await _context.courses.FindAsync(courseId);
            if (existingCourse != null)
            {
                existingCourse.course_name = updateCourseDto.course_name ?? existingCourse.course_name;
                existingCourse.course_description = updateCourseDto.course_description ?? existingCourse.course_description;
                existingCourse.course_price = updateCourseDto.course_price ?? existingCourse.course_price;
                existingCourse.course_goal = updateCourseDto.course_goal ?? existingCourse.course_goal;
                existingCourse.course_created_at = updateCourseDto.course_created_at ??existingCourse.course_created_at;
                existingCourse.total_rating = updateCourseDto.total_rating ?? existingCourse.total_rating;
                existingCourse.total_member = updateCourseDto.total_member ?? existingCourse.total_member;
                existingCourse.course_image_url = updateCourseDto.course_image_url ?? existingCourse.course_image_url;
                existingCourse.instructor_id = updateCourseDto.instructor_id ?? existingCourse.instructor_id;  
                _context.courses.Update(existingCourse);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<CreateCourseDto>(existingCourse);
        }

        public async Task<bool> DeleteCoursesAsync(string courseId)
        {
            var existingCourse = await _context.courses.FindAsync(courseId);
            if (existingCourse != null)
            {
                 _context.courses.Remove(existingCourse);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<string>> DeleteCoursesAsync(List<string> courseIds)
        {
            var deletedUrls = new List<string>();

            var coursesToDelete = await _context.courses
                .Include(c=> c.courseDetails)
                .ThenInclude(cd => cd.lectures)
                .Where(c => courseIds.Contains(c.course_id))
                .ToListAsync();

            if (coursesToDelete.Count != 0)
            {
                deletedUrls.AddRange(coursesToDelete.Select(c => c.course_image_url));
                deletedUrls.AddRange(coursesToDelete
                    .SelectMany(c => c.courseDetails)
                    .SelectMany(cd => cd.lectures)
                    .Select(lecture => lecture.video_url)
                    .ToList());

                _context.courses.RemoveRange(coursesToDelete);
                await _context.SaveChangesAsync();
            }

            return deletedUrls;
        }
     
       
    }
}
