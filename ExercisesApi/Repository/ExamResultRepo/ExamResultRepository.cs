using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ExercisesApi.Repository.ExamResultRepo
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ExamResultRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }

        public async Task AddExamResultAsync(CreateExamResultDto createExamResultDto)
        {
            var newExamresult = _mapper.Map<ExamResult>(createExamResultDto);
            await _context.exam_results.AddAsync(newExamresult);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExamResultAsync(string examResultId)
        {
            var existExamResult = await _context.exam_results.FindAsync(examResultId);
            if (existExamResult != null)
            {
                _context.exam_results.Remove(existExamResult);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteExamResultsAsync(List<string> examResultIds)
        {
            foreach (var examResultId in examResultIds)
            {
                var existExamResult = await _context.exam_results.FindAsync(examResultId);
                if (existExamResult != null)
                {
                    _context.exam_results.Remove(existExamResult);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        

        public async Task<GetExamResultDto> GetExamResultByIdAsync(string examResultId)
        {
            var examResult = await _context.exam_results
                .Include(er => er.examResultDetails)
                    .ThenInclude(erd => erd.question)
                        .ThenInclude(q => q.answer)
                .Include(er => er.exercise)
                .Where(er => er.exam_result_id == examResultId)
                .FirstOrDefaultAsync();

            if (examResult == null)
            {
                return null;
            }

            var resultDto = new GetExamResultDto
            {
                exam_result_id = examResult.exam_result_id,
                time_limit = examResult.time_limit,
                uid = examResult.uid,
                exercise_id = examResult.exercise_id,
                title_of_exercise = examResult.exercise.title_of_exercise,
                score = examResult.score,
                total_score_listening = examResult.total_score_listening,
                total_score_reading = examResult.total_score_reading,
                total_right = examResult.total_right,
                total_wrong = examResult.total_wrong,
                date = examResult.date,
                exam_result_details = examResult.examResultDetails.Select(erd => new GetExamResultDetailDto
                {
                    question_id = erd.question_id,
                    question_content = erd.question.question_content,
                    answer_of_user = erd.answer_of_user,
                    answer_explanation = erd.question.answer.answer_explanation,
                    corect_answer = erd.question.answer.corect_answer
                }).ToList()
            };

            return resultDto;
        }

        public async Task<GetExamResultDto> GetExamResultsByExerciseIdAndUidAsync(string exerciseId, string uid)
        {
            var examResult = await _context.exam_results
                .Include(er => er.examResultDetails)
                    .ThenInclude(erd => erd.question)
                        .ThenInclude(q => q.answer)
                .Include(er => er.exercise)
                .Where(er => er.exercise_id == exerciseId && er.uid == uid)
                .FirstOrDefaultAsync();

            if (examResult == null)
            {
                return null;
            }

            var resultDto = new GetExamResultDto
            {
                exam_result_id = examResult.exam_result_id,
                time_limit = examResult.time_limit,
                uid = examResult.uid,
                exercise_id = examResult.exercise_id,
                title_of_exercise = examResult.exercise.title_of_exercise,
                score = examResult.score,
                total_score_listening = examResult.total_score_listening,
                total_score_reading = examResult.total_score_reading,
                total_right = examResult.total_right,
                total_wrong = examResult.total_wrong,
                date = examResult.date,
                exam_result_details = examResult.examResultDetails.Select(erd => new GetExamResultDetailDto
                {
                    question_id = erd.question_id,
                    question_content = erd.question.question_content,
                    answer_of_user = erd.answer_of_user,
                    answer_explanation = erd.question.answer.answer_explanation,
                    corect_answer = erd.question.answer.corect_answer
                }).ToList()
            };

            return resultDto;
        }

        public async Task<List<CreateExamResultDto>> GetExamResultsByUserIdAsync(string uid)
        {
            try
            {
                var examResults = await _context.exam_results
                    .Include(er => er.exercise)
                    .Where(er => er.uid == uid)
                    .ToListAsync();
                if (examResults == null || examResults.Count == 0)
                {
                    return new List<CreateExamResultDto>();
                }
                var resultPerDay = new Dictionary<string, int>();
              
                var response = new List<CreateExamResultDto>();
                foreach (var examResult in examResults)
                {                  
                    var newEx = new CreateExamResultDto
                    {
                        exam_result_id = examResult.exam_result_id,
                        exercise_id = examResult.exercise_id,
                        title_of_exercise = examResult.exercise.title_of_exercise,
                        time_limit = examResult.time_limit,
                        score = examResult?.score,
                        total_right = examResult.total_right,
                        total_wrong = examResult.total_wrong,
                        total_score_listening = examResult.total_score_listening,
                        total_score_reading = examResult.total_score_reading,
                        uid = examResult.uid,
                        date = examResult.date,
                        category_detai_id = examResult.exercise.category_detail_id,              
                    };
                    response.Add(newEx);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching exam results.", ex);
            }
        }

        public async Task<List<GetAverageExamResultPerDayDto>> GetExamResultsByUserIdFromTimeRangeAsync(string uid, string fromDate, string toDate)
        {
            try
            {
                var fromDateUtc = DateOnly.Parse(fromDate);
                var toDateUtc = toDate == "currentdate" ? DateOnly.FromDateTime(DateTime.UtcNow) : DateOnly.Parse(toDate);

                var allExamResults = await _context.exam_results
                    .Include(er => er.exercise)
                    .Where(er => er.uid == uid)
                    .ToListAsync();

                var filteredResults = allExamResults
                    .Where(er => DateOnly.Parse(er.date) >= fromDateUtc && DateOnly.Parse(er.date) <= toDateUtc)
                    .ToList();

                if (filteredResults == null || filteredResults.Count == 0)
                {
                    return new List<GetAverageExamResultPerDayDto>();
                }

                var resultPerDay = new Dictionary<DateOnly, (int count, double totalScore)>();

                foreach (var examResult in filteredResults)
                {
                    var date = DateOnly.Parse(examResult.date);

                    if (!resultPerDay.ContainsKey(date))
                    {
                        resultPerDay[date] = (0, 0);
                    }

                    resultPerDay[date] = (resultPerDay[date].count + 1, resultPerDay[date].totalScore + examResult.score);
                }

                var response = resultPerDay.Select(kv => new GetAverageExamResultPerDayDto
                {
                    date = kv.Key.ToString(),
                    countExamReultPerDate = kv.Value.count,
                    averageScorePerDate = kv.Value.count > 0 ? (int)(kv.Value.totalScore / kv.Value.count) : 0
                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching exam results.", ex);
            }
        }




    }
}
