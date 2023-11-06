using AutoMapper;
using CoursesApi.DTO;
using CoursesApi.Model;

namespace CoursesApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateCourseDto, Courses>().ReverseMap()
                .ForMember(dest => dest.course_id, opt => opt.MapFrom(src => src.course_id))
                .ForMember(dest => dest.course_description, opt => opt.MapFrom(src => src.course_description))
                .ForMember(dest => dest.course_name, opt => opt.MapFrom(src => src.course_name))
                .ForMember(dest => dest.course_price, opt => opt.MapFrom(src => src.course_price))
                .ForMember(dest => dest.course_goal, opt => opt.MapFrom(src => src.course_goal))
                .ForMember(dest => dest.course_image_url, opt => opt.MapFrom(src => src.course_image_url))
                .ForMember(dest => dest.total_member, opt => opt.MapFrom(src => src.total_member))
                .ForMember(dest => dest.total_rating, opt => opt.MapFrom(src => src.total_rating));

            CreateMap<CreateInstructorDto, Instructors>().ReverseMap()
                .ForMember(dest => dest.instructor_id, opt => opt.MapFrom(src => src.instructor_id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.image_url, opt => opt.MapFrom(src => src.image_url));

            CreateMap<CreateLectureDto, Lectures>().ReverseMap()
                 .ForMember(dest => dest.lecture_id, opt => opt.MapFrom(src => src.lecture_id))
                .ForMember(dest => dest.lecture_title, opt => opt.MapFrom(src => src.lecture_title))
                .ForMember(dest => dest.lecture_index, opt => opt.MapFrom(src => src.lecture_index))
                .ForMember(dest => dest.video_url, opt => opt.MapFrom(src => src.video_url))
                .ForMember(dest => dest.course_detail_id, opt => opt.MapFrom(src => src.course_detail_id))
                .ForMember(dest => dest.content, opt => opt.MapFrom(src => src.content));

            CreateMap<CreateRatingDto, Ratings>().ReverseMap();


            CreateMap<CreateCourseDetailDto, CourseDetails>().ReverseMap();
            CreateMap<CreateEnrollmentDto, Enrollments>().ReverseMap();

        }
    }
}
