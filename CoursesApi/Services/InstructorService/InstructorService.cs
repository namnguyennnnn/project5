using CoursesApi.DTO;
using CoursesApi.Model;
using CoursesApi.Repository.InstructorRepo;
using CoursesApi.Services.FileService;

namespace CoursesApi.Services.InstructorService
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;
        public InstructorService(IInstructorRepository instructorRepository, IFileService fileService)
        {
            _instructorRepository = instructorRepository;
            _fileService = fileService;
        }

        public async Task<StatusResponse> CreateInstructor(CreateInstructorDto createInstructorDto)
        {
            if (createInstructorDto == null)
            {
                throw new ArgumentNullException("createInstructorDto", "Please provide valid data");
            }

            if (string.IsNullOrEmpty(createInstructorDto.name) || string.IsNullOrEmpty(createInstructorDto.bio))
            {
                return new StatusResponse { StatusCode = 400, StatusDetail = "Name and bio cannot be empty" };
            }

            if (createInstructorDto.imageFile == null)
            {
                return new StatusResponse { StatusCode = 400, StatusDetail = "Image file is required" };
            }

            try
            {
                var imageUrl = await _fileService.UploadFileAsync(createInstructorDto.imageFile);
                var newInstructor = new CreateInstructorDto
                {
                    instructor_id = Guid.NewGuid().ToString(),
                    name = createInstructorDto.name,
                    bio = createInstructorDto.bio,
                    image_url = imageUrl
                };

                await _instructorRepository.AddInstructorAsync(newInstructor);

                return new StatusResponse { StatusCode = 200, StatusDetail = "Create Instructor Success" };
            }
            catch (Exception ex)
            {
                return new StatusResponse { StatusCode = 500, StatusDetail = "An error occurred: " + ex.Message };
            }
        }


        public async Task<CreateInstructorDto> GetInstructorById(string instructorId)
        {
            if (string.IsNullOrWhiteSpace(instructorId))
            {
                throw new ArgumentNullException(nameof(instructorId), "Please provide a valid instructor ID");
            }

            try
            {
                var instructor=  await _instructorRepository.GetInstructorByIdAsync(instructorId);
                instructor.image_url = await _fileService.GetSignedUrl(instructor.image_url);
                return instructor;
            }
            catch (Exception ex)
            {

                return null; 
            }
        }


        public async Task<List<CreateInstructorDto>> GetInstructors()
        {
            var instructors = await _instructorRepository.GetInstructorsAsync();
           
            foreach (var instructor in instructors)
            {
                instructor.image_url = await _fileService.GetSignedUrl(instructor.image_url);
            }

            return instructors;
        }

        public async Task<CreateInstructorDto> UpdateInstructor(string instructorId, CreateInstructorDto updateInstructorDto)
        {
            if (string.IsNullOrWhiteSpace(instructorId)|| updateInstructorDto == null)
            {
                throw new ArgumentNullException(nameof(instructorId), "Please provide a valid instructor ID");
            }

            var existInstructor = await _instructorRepository.GetInstructorByIdAsync(instructorId);
            if (existInstructor == null)
            {
                return null;
            }
            if (updateInstructorDto.imageFile != null) 
            {
                var urls = new List<string>();
                urls.Add(existInstructor.image_url);
                await _fileService.DeleteFilesAsync(urls);
                var url = await _fileService.UploadFileAsync(updateInstructorDto.imageFile);
                updateInstructorDto.image_url = url;
            }
            var instructor =  await _instructorRepository.UpdateInstructorAsync(instructorId, updateInstructorDto);
            instructor.image_url = await _fileService.GetSignedUrl(instructor.image_url);
            return instructor;
        }
        public async Task<StatusResponse> DeleteInstructor(List<string> instructorIds)
        {
            if (instructorIds.Count == 0)
            {
                throw new Exception("Please submit non null value");
            }

            var url = await _instructorRepository.DeleteInstructorsAsync(instructorIds);
            if (url.Count != 0)
            {
                await _fileService.DeleteFilesAsync(url);
                return new StatusResponse { StatusCode = 200, StatusDetail = "Delete Success" };
            }

            return new StatusResponse { StatusCode = 404, StatusDetail = "Delete Failed" };
        }
    }
}
