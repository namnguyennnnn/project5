using Grpc.Core;
using ExercisesApi.Repository.ExerciseRepo;
using ExerciseManagement;
using CatagoryDetailsManagement;
using Grpc.Net.Client;
using ExercisesApi.Repository.ExamResultRepo;

namespace ExercisesApi.Services
{
    public class ExerciseGrpcFunction : ExerciseManagement.ExerciseManager.ExerciseManagerBase
    {
        private readonly IExerciseRepository _exerciseRepository;   
        private readonly IExamResultRepository _examResultRepository;
        private readonly GrpcChannel _channelCategory; 
        public ExerciseGrpcFunction(IExerciseRepository exerciseRepository, IExamResultRepository examResultRepository)
        {
            _exerciseRepository = exerciseRepository;
            _examResultRepository = examResultRepository;
            _channelCategory = GrpcChannelManager.CategoryChannel;
        }
        public override async Task<GetExerciseResponse> GetExercise(GetExerciseRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(request.ExerciseId);

            return await Task.FromResult(new GetExerciseResponse
            {
                ExerciseId = exercise.exercise_id,
                CategoryDetailId = exercise.category_detail_id,
                TitleOfExercise =exercise.title_of_exercise,
                ExerciseDescription =exercise.exercise_description,
                CreateAt = exercise.create_at
            });
           
        }
        public override async Task<DeleteExercisesResponse> DeleteExercises(DeleteExercisesRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _exerciseRepository.DeleteExercisesByCategoryDetailIdAsync(request.CategoryDetailId);

            return await Task.FromResult(new DeleteExercisesResponse
            {
                Status = 200
            });
        }

        public override async Task<GetExamResultsByUserIdResponse> GetExamResultsByUserId(GetExamResultsByUserIdRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var examResults = await _examResultRepository.GetExamResultsByUserIdAsync(request.Uid);
            if (examResults == null)
            {
                return new GetExamResultsByUserIdResponse{ };
            }
            var client = new CatagoryDetailsManagement.CatagoryDetailManager.CatagoryDetailManagerClient(_channelCategory);

            var result = new GetExamResultsByUserIdResponse();
            foreach (var examResult in examResults)
            {
                var response = client.GetCatagoryDetailInFor(new GetCatagoryDetailInForRequest { CategoryDetailId = examResult.category_detai_id });

                var newExamResult = new ExamResultsPGrpcModel
                {
                    ExamResultId = examResult.exam_result_id,
                    ExerciseId = examResult.exercise_id,
                    TitleOfExercise = examResult.title_of_exercise,
                    Score = examResult.score ?? 0,
                    TimeLimit = examResult.time_limit.ToString(),
                    TotalScoreListening = examResult.total_score_listening ?? 0,
                    TotalScoreReading = examResult.total_score_reading ?? 0,
                    TotalRight = examResult.total_right ?? 0,
                    TotalWrong = examResult.total_wrong ?? 0,
                    Date = examResult.date,
                    CategoryDetailName = response.CategoryDetailName,
                    CategoryName = response.CategoryName
                };
                result.Examresults.Add(newExamResult);
            }
            return await Task.FromResult(result);
        }
        public override async Task<GetExamResultsFromTimeRangeByUserIdResponse> GetExamResultsFromTimeRangeByUserId(GetExamResultsFromTimeRangeByUserIdRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var examResults = await _examResultRepository.GetExamResultsByUserIdFromTimeRangeAsync(request.Uid, request.From, request.To);
            if (examResults == null)
            {
                return new GetExamResultsFromTimeRangeByUserIdResponse { };
            }
            var result = new GetExamResultsFromTimeRangeByUserIdResponse();

            if (examResults != null && examResults.Count > 0)
            {
                foreach (var examResult in examResults)
                {                 
                    var newExamResult = new ExamResultsPerDayGrpcModel
                    {                       
                        Date = examResult.date,
                        AvarageScore = examResult.averageScorePerDate

                    };
                    result.Examresultsperday.Add(newExamResult);
                }
            }
            return await Task.FromResult(result);
        }
        public override async Task<GetExamResultsByIdResponse> GetExamResultsById(GetExamResultsByIdRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var examResult = await _examResultRepository.GetExamResultByIdAsync(request.ExamResultId);
            if (examResult == null)
            {
                return new GetExamResultsByIdResponse { };
            }
            var examResultDetails = new List<ExamResultDetailsPGrpcModel>();
            foreach (var examresultdetail in examResult.exam_result_details)
            {
                var newErd = new ExamResultDetailsPGrpcModel
                {
                    QuestionId = examresultdetail.question_id,
                    QuestionContent = examresultdetail.question_content,
                    CorectAnswer = examresultdetail.corect_answer,
                    AnswerOfUser = examresultdetail.answer_of_user,
                    AnswerExplanation = examresultdetail.answer_explanation
                };
                examResultDetails.Add(newErd);
            }

            var response = new GetExamResultsByIdResponse
            {
                ExamResultId = examResult.exam_result_id,
                TimeLimit = examResult.time_limit,
                ExerciseId = examResult.exercise_id,
                TitleOfExercise =examResult.title_of_exercise,
                Score = examResult.score ?? 0,
                TotalScoreListening = examResult.total_score_listening ?? 0,
                TotalScoreReading = examResult.total_score_reading ?? 0,
                TotalRight = examResult.total_right ?? 0,
                TotalWrong = examResult.total_wrong ?? 0,
                Uid = examResult.uid,
                Date = examResult.date
            };

            response.Examresultdetails.AddRange(examResultDetails);
            return await Task.FromResult(response);
        }
        public override async Task<GetExamResultsByExerciseIdAndUidResponse> GetExamResultsByExerciseIdAndUid(GetExamResultsByExerciseIdAndUidResquest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var examResult = await _examResultRepository.GetExamResultsByExerciseIdAndUidAsync(request.ExerciseId , request.Uid);
            if(examResult == null)
            {
                return new GetExamResultsByExerciseIdAndUidResponse { };
            }
            var examResultDetails = new List<ExamResultDetailsPGrpcModel>();
            foreach (var examresultdetail in examResult.exam_result_details)
            {
                var newErd = new ExamResultDetailsPGrpcModel
                {
                    QuestionId = examresultdetail.question_id,
                    QuestionContent = examresultdetail.question_content,
                    CorectAnswer = examresultdetail.corect_answer,
                    AnswerOfUser = examresultdetail.answer_of_user,
                    AnswerExplanation = examresultdetail.answer_explanation
                };
                examResultDetails.Add(newErd);
            }

            var response = new GetExamResultsByExerciseIdAndUidResponse
            {
                ExamResultId = examResult.exam_result_id,
                TimeLimit = examResult.time_limit,
                ExerciseId = examResult.exercise_id,
                TitleOfExercise = examResult.title_of_exercise,
                Score = examResult.score ?? 0,
                TotalScoreListening = examResult.total_score_listening ?? 0,
                TotalScoreReading = examResult.total_score_reading ?? 0,
                TotalRight = examResult.total_right ?? 0,
                TotalWrong = examResult.total_wrong ?? 0,
                Uid = examResult.uid,
                Date = examResult.date
            };

            response.Examresultdetails.AddRange(examResultDetails);
            return await Task.FromResult(response);
        }

        public async override Task<DeleteExamResultResponse> DeleteExamResult(DeleteExamResultRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var isDelete =  await _examResultRepository.DeleteExamResultAsync(request.ExamResultId);
            if (isDelete == false)
            {
                return await Task.FromResult(new DeleteExamResultResponse
                {
                    Status = 404,                   
                });
            }
            return await Task.FromResult(new DeleteExamResultResponse
            {
                Status = 200
            });
        }
        public override async Task<DeleteExamResultsResponse> DeleteExamResults(DeleteExamResultsRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var ids = new List<string>();
            foreach (var exid in request.ExamResultIds)
            {
                ids.Add(exid.ExamResultId);
            }
            await _examResultRepository.DeleteExamResultsAsync(ids);
            return await Task.FromResult(new DeleteExamResultsResponse
            {
                Status= 200
            });

        }
    }
}