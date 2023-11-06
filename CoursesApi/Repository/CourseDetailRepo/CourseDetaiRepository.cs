using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repository.CourseDetailRepo
{
    public class CourseDetaiRepository : ICourseDetaiRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CourseDetaiRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCourseDetailAsync(CreateCourseDetailDto courseDetailDto)
        {
            var newCourseDetails = _mapper.Map<CourseDetails>(courseDetailDto);
            await _context.course_details.AddAsync(newCourseDetails);
            await _context.SaveChangesAsync();
        }
        public async Task AddCourseDetaislAsync(List<CreateCourseDetailDto> courseDetailDtos)
        {
            var newCourseDetails = _mapper.Map<List<CourseDetails>>(courseDetailDtos);
            await _context.course_details.AddRangeAsync(newCourseDetails);
            await _context.SaveChangesAsync();
        }


        public async Task<List<CreateCourseDetailDto>> GetCourseDetailsAsync()
        {
            var listCourseDetails = await _context.course_details.ToListAsync();
            return _mapper.Map<List<CreateCourseDetailDto>>(listCourseDetails);
        }

        public async Task UpdateCourseDetailsAsync(List<CreateCourseDetailDto> courseDetails)
        {
           foreach (var updateCourseDetail in courseDetails)
            {
                var existCourseDetail = await _context.course_details.FirstOrDefaultAsync(cd => cd.course_detail_id == updateCourseDetail.course_detail_id );
                if (existCourseDetail != null)
                {
                    existCourseDetail.course_detail_name = updateCourseDetail.course_detail_name ?? existCourseDetail.course_detail_name;
                    existCourseDetail.course_id = updateCourseDetail.course_id ?? existCourseDetail.course_id;
                    existCourseDetail.total_lecture = updateCourseDetail.total_lecture ?? existCourseDetail.total_lecture;
                    existCourseDetail.course_detail_index = updateCourseDetail.course_detail_index ?? existCourseDetail.course_detail_index;
                    _context.course_details.Update(existCourseDetail);
                }
                               
            }
           await _context.SaveChangesAsync();
           
        }
        public async Task<bool> DeleteCourseDetailAsync(string courseDetailId)
        {
            var existCourseDetail = await _context.course_details.FindAsync(courseDetailId);
            if (existCourseDetail != null)
            {
                _context.course_details.Remove(existCourseDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCourseDetailsAsync(List<string> courseDetailId)
        {
            var listCoursedetails = await _context.course_details.Where(cd => courseDetailId.Contains(cd.course_detail_id)).ToListAsync();
            if(listCoursedetails.Count != 0)
            {
                _context.course_details.RemoveRange(listCoursedetails);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
