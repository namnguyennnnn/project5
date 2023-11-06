using CoursesApi.DTO;
using CoursesApi.Model;
using CoursesApi.Repository.CourseDetailRepo;
using CoursesApi.Repository.CourseRepo;
using CoursesApi.Repository.EnrollmentRepo;
using CoursesApi.Repository.LectureRepo;
using CoursesApi.Repository.RatingRepo;
using CoursesApi.Services.FileService;
using Grpc.Net.Client;
using System.Diagnostics;
using UserManagement;

namespace CoursesApi.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseDetaiRepository _courseDetaiRepository;
        private readonly IFileService _fileService;
        private readonly ILectureRepository _lectureRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        
        private readonly GrpcChannel _userChannel;
        public CourseService(ICourseRepository courseRepository,
            ICourseDetaiRepository courseDetaiRepository,
            IFileService fileService,
            ILectureRepository lectureRepository,
            IEnrollmentRepository enrollmentRepository
            
            )
        {
            _courseRepository = courseRepository;
            _courseDetaiRepository = courseDetaiRepository;
            _fileService = fileService;
            _userChannel = GrpcChannelManager.UserChannel;
            _lectureRepository = lectureRepository;
            _enrollmentRepository = enrollmentRepository;
           
        }

        public async Task<GetCourseDto> CreateCourse(CreateCourseRequestDto courseDto)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // Start measuring time    
            try
            {
                if (courseDto.CourseDto == null || courseDto.CourseDetailDtos == null)
                {
                    throw new ArgumentNullException("Please submit valid object");
                }
                var courseId = Guid.NewGuid().ToString();
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                var courseDetailBatchs = new List<CreateCourseDetailDto>();
                var lectureBatchs = new List<CreateLectureDto>();
                if (courseDto.CourseDto.courseImageFile == null)
                {            
                    throw new Exception("CourseImageFile can't not be null");
                }
                var Imageurl = await _fileService.UploadFileAsync(courseDto.CourseDto.courseImageFile);
                if (Imageurl == null)
                {
                    throw new Exception("CourseImageFile can't not be null");
                }
                var newCourse = new CreateCourseDto
                {
                    course_id = courseId,
                    course_name = courseDto.CourseDto.course_name,
                    course_description = courseDto.CourseDto.course_description,
                    course_goal = courseDto.CourseDto.course_goal,
                    course_price = courseDto.CourseDto.course_price,
                    course_image_url = Imageurl,
                    total_member = 0,
                    total_rating = 0,
                    average_score_rating = 0,
                    course_created_at = localTime.ToString(),
                    instructor_id = courseDto.CourseDto.instructor_id,
                };
                await _courseRepository.AddCoursAsync(newCourse);
                foreach (var coursedetail in courseDto.CourseDetailDtos)
                {
                    var newCourseDetail = new CreateCourseDetailDto
                    {
                        course_detail_id = Guid.NewGuid().ToString(),
                        course_detail_name = coursedetail.course_detail_name,
                        course_detail_index = coursedetail.course_detail_index,
                        total_lecture = 0,
                        course_id = courseId
                    };
                    courseDetailBatchs.Add(newCourseDetail);

                    foreach (var lecture in coursedetail.LectureDtos)
                    {
                        if (lecture.videoFile != null)
                        {
                            var videoUrl = await _fileService.UploadFileAsync(lecture.videoFile);
                            var newLecture = new CreateLectureDto
                            {
                                lecture_id = Guid.NewGuid().ToString(),
                                lecture_title = lecture.lecture_title,
                                content = lecture.content,
                                lecture_index = lecture.lecture_index,
                                video_url = videoUrl,
                                course_detail_id = newCourseDetail.course_detail_id
                            };
                            lectureBatchs.Add(newLecture);
                        }
                        else
                        {
                            throw new ArgumentNullException($"Video file of lecture_index{lecture.lecture_index} null");
                        }

                    }

                }
                await _courseDetaiRepository.AddCourseDetaislAsync(courseDetailBatchs);
                await _lectureRepository.AddLecturesAsync(lectureBatchs);
                return new GetCourseDto 
                {
                    course_id = newCourse.course_id,
                    course_name =newCourse.course_name,
                    course_description = newCourse.course_description,
                    course_image_url = await _fileService.GetSignedUrl(newCourse.course_image_url),
                    course_price = newCourse.course_price,
                    total_member = newCourse.total_member,
                    total_rating = newCourse.total_rating,
                    average_score_rating = newCourse.average_score_rating,
                    course_goal = newCourse.course_goal,    
                    course_created_at = newCourse.course_created_at,
                    instructor_id = newCourse.instructor_id
                };
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                stopwatch.Stop(); // Stop measuring time
                TimeSpan elapsed = stopwatch.Elapsed;

                Console.WriteLine($"CreateExercise took {elapsed.TotalSeconds} seconds");
            }
        }
        public async Task<GetCourseDto> EnrollmentCourse(string uid, string courseId)
        {

            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(courseId))
            {
                throw new ArgumentNullException("Please submit non nul data");
            }
            var newEnrollment = new CreateEnrollmentDto
            {
                enrollment_id = Guid.NewGuid().ToString(),
                uid = uid,
                course_id = courseId,
                enrollment_date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")).ToString()
            };
            if (await _enrollmentRepository.AddEnrollmentAsync(newEnrollment) == false)
            {
                return null;
            }
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
            course.instructor.image_url = await _fileService.GetSignedUrl(course.instructor.image_url);
            foreach (var courseDetail in course.courseDetailDtos)
            {
                foreach (var lecture in courseDetail.LectureDtos)
                {
                    lecture.video_url = await _fileService.GetSignedUrl(lecture.video_url);
                }
            }
            return course;
        }
        public async Task<GetCourseDto> GetCourseByCourseId(string courseId,string uid)
        {
            if (courseId == null)
            {
                throw new Exception("Please provide valid data");
            }
           
                var course = await _courseRepository.GetCourseByIdAsync(courseId);
                course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
                course.instructor.image_url = await _fileService.GetSignedUrl(course.instructor.image_url);
                foreach (var courseDetail in course.courseDetailDtos)
                {
                    foreach (var lecture in courseDetail.LectureDtos)
                    {
                        lecture.video_url = await _fileService.GetSignedUrl(lecture.video_url);
                    }
                }
                if (course == null)
                {
                    return null;
                }
                var uids = course.ratingDtos.Select(r => r.uid).ToList();
                var client = new UserManager.UserManagerClient(_userChannel);
                var userRequests = uids.Select(uid => new UserIds { Uid = uid }).ToList();
                var getUsersByIdsResponse = client.GetUsersByIds(new GetUsersByIdsRequest { Uids = { userRequests } });
                if(getUsersByIdsResponse.InforUsers.Count != 0)
                {
                    foreach (var ratingDto in course.ratingDtos)
                    {
                        var user = getUsersByIdsResponse.InforUsers.FirstOrDefault(u => u.Uid == ratingDto.uid);
                        if (user != null)
                        {
                            ratingDto.user_name = user.UserName;
                            ratingDto.avartar = user.Avatar;
                        }
                    }
                }
                if (await _enrollmentRepository.IsEnrollAsync(courseId, uid) == true)
                {
                    course.isEnroll = true;
                }
                else
                {
                    course.isEnroll = false;
                }
                return course;
            
            
            
        }

        public async Task<GetCourseDto> GetCourseByCourseIdWithoutUid(string courseId)
        {
            if (courseId == null)
            {
                throw new Exception("Please provide valid data");
            }

            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
            course.instructor.image_url = await _fileService.GetSignedUrl(course.instructor.image_url);
            foreach (var courseDetail in course.courseDetailDtos)
            {
                foreach (var lecture in courseDetail.LectureDtos)
                {
                    lecture.video_url = await _fileService.GetSignedUrl(lecture.video_url);
                }
            }
            if (course == null)
            {
                return null;
            }
            var uids = course.ratingDtos.Select(r => r.uid).ToList();
            var client = new UserManager.UserManagerClient(_userChannel);
            var userRequests = uids.Select(uid => new UserIds { Uid = uid }).ToList();
            var getUsersByIdsResponse = client.GetUsersByIds(new GetUsersByIdsRequest { Uids = { userRequests } });
            foreach (var ratingDto in course.ratingDtos)
            {
                var user = getUsersByIdsResponse.InforUsers.FirstOrDefault(u => u.Uid == ratingDto.uid);
                if (user != null)
                {
                    ratingDto.user_name = user.UserName;
                    ratingDto.avartar = user.Avatar;
                }
            }
            course.isEnroll = false;
            return course;
        }
        public async Task<List<CreateCourseDto>> GetCoursesExcludingErollment(string uid)
        {
            if (uid == null)
            {
                throw new Exception("Please provide valid data");
            }
            var courses = await _courseRepository.GetCoursesExcludingErollmentAsync(uid);
            foreach (var course in courses)
            {
                course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
            }
            if (courses.Count == 0)
            {
                return null;
            }
            return courses;
        }

        public async Task<List<CreateCourseDto>> GetCoursesOfUser(string uid)
        {
            if (uid == null)
            {
                throw new Exception("Please provide valid data");
            }
            var courses = await _courseRepository.GetCoursesOfUserAsync(uid);
            foreach (var course in courses)
            {
                course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
            }
            if (courses.Count == 0)
            {
                return null;
            }
            return courses;
        }

        public async Task<List<CreateCourseDto>> GetCourses()
        {
            var courses = await _courseRepository.GetCoursesAsync();
            foreach (var course in courses)
            {
                course.course_image_url = await _fileService.GetSignedUrl(course.course_image_url);
            }
            if (courses.Count == 0)
            {
                return null;
            }
            return courses;
        }

        public async Task<GetCourseDto> UpdateCourse(string courseId, CreateCourseRequestDto courseDto)
        {

            var course = await _courseRepository.GetCourseByIdForUpdateAsync(courseId);
            if (course == null)
            {
                return null;
            }
            if (courseDto.CourseDto != null)
            {
                var newCourse = new CreateCourseDto
                {
                    course_name = courseDto.CourseDto.course_name,
                    course_description = courseDto.CourseDto.course_description,
                    course_goal = courseDto.CourseDto.course_goal,
                    course_price = courseDto.CourseDto.course_price,
                    instructor_id = courseDto.CourseDto.instructor_id
                };

                if (courseDto.CourseDto.courseImageFile != null)
                {
                    var imageUrl = await _fileService.UploadFileAsync(courseDto.CourseDto.courseImageFile);
                    newCourse.course_image_url = imageUrl;
                }

                await _courseRepository.UpdateCoursAsync(courseId, newCourse);

            }
            if (courseDto.CourseDetailDtos != null)
            {
                var lectureBatchs = new List<CreateLectureDto>();
                await _courseDetaiRepository.UpdateCourseDetailsAsync(courseDto.CourseDetailDtos);
                foreach (var lectures in courseDto.CourseDetailDtos)
                {
                    foreach (var lecture in lectures.LectureDtos)
                    {
                        var newLecture = new CreateLectureDto
                        {
                            lecture_title = lecture.lecture_title,
                            content = lecture.content,
                            lecture_index = lecture.lecture_index,

                            course_detail_id = lecture.course_detail_id
                        };

                        if (lecture.videoFile != null)
                        {
                            var videoUrl = await _fileService.UploadFileAsync(lecture.videoFile);
                            newLecture.video_url = videoUrl;
                        }

                        lectureBatchs.Add(newLecture);
                    }
                }
                await _lectureRepository.UpdateLectureAsync(lectureBatchs);
            }

            var courseinfo = await _courseRepository.GetCourseByIdForUpdateAsync(courseId);
            courseinfo.course_image_url = await _fileService.GetSignedUrl(courseinfo.course_image_url);
            courseinfo.instructor.image_url = await _fileService.GetSignedUrl(courseinfo.instructor.image_url);
            foreach (var courseDetail in courseinfo.courseDetailDtos)
            {
                foreach (var lecture in courseDetail.LectureDtos)
                {
                    lecture.video_url = await _fileService.GetSignedUrl(lecture.video_url);
                }
            }
            return courseinfo;
        }

        public async Task<StatusResponse> DeleteCourses(List<string> courseIds)
        {
            if (courseIds.Count == 0)
            {
                throw new Exception("Please submit non null value");
            }

            var url = await _courseRepository.DeleteCoursesAsync(courseIds);
            if (url.Count != 0)
            {
                await _fileService.DeleteFilesAsync(url);
                return new StatusResponse { StatusCode = 200, StatusDetail = "Delete Success" };
            }

            return new StatusResponse { StatusCode = 404, StatusDetail = "Delete Failed" };
        }

       
    }
}
