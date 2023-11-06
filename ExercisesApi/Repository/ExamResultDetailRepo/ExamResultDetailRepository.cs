using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.ExamResultDetailRepo
{
    public class ExamResultDetailRepository: IExamResultDetailRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ExamResultDetailRepository(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddExamResultDetailsAsync(List<CreateExamResultDetailDto> createExamResultsDetailDto)
        {
            var newExamResultDetails = _mapper.Map<List<ExamResultDetail>>(createExamResultsDetailDto);

            foreach (var detail in newExamResultDetails)
            {
                await _context.exam_result_details.AddAsync(detail);
            }

            await _context.SaveChangesAsync();
        }
    }
}
