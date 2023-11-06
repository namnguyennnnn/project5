using AutoMapper;
using CoursesApi.Data;
using CoursesApi.DTO;
using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repository.EnrollmentRepo
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EnrollmentRepository(DataContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddEnrollmentAsync(CreateEnrollmentDto enrollmentdto)
        {
            var existtingEnrollment = await _context.enrollments.FirstOrDefaultAsync(e => e.course_id == enrollmentdto.course_id && e.uid == enrollmentdto.uid);
            if(existtingEnrollment == null)
            {
                var newEnrollment = _mapper.Map<Enrollments>(enrollmentdto);
                await _context.enrollments.AddAsync(newEnrollment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> IsEnrollAsync(string courseId, string uid)
        {
            var existtingEnrollment = await _context.enrollments.FirstOrDefaultAsync(e => e.course_id == courseId && e.uid == uid);
            if( existtingEnrollment == null)
            {
                return false;
            }
            return true;
        }
    }
}
