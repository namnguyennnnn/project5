
using Grpc.Net.Client;
using UserApi.DTO;
using UserApi.Repositiory.UserRepo;
using UserApi.Services.FileService;
using ExerciseManagement;

namespace UserApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        private GrpcChannel _exerciseChannel;
        public UserService(IUserRepository userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
            _exerciseChannel = GrpcChannelManager.ExerciseChannel;
        }

        public async Task<GetUserDto> GetUserById(string uid)
        {
            if(uid ==null)
            {
                throw new ArgumentNullException(nameof(uid));               
            }

            return await _userRepository.GetUserByIdAsync(uid);
        }

        public async Task<List<GetUserDto>> GetUsers()
        {
            return await _userRepository.GetUsersAsync();
        }
        public async Task<List<ExamResultDto>> GetExamResultsByUserId(string uid)
        {
            if (string.IsNullOrEmpty(uid)){
                throw new ArgumentException("Please provide valid uid");
            }

            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var response = client.GetExamResultsByUserId(new GetExamResultsByUserIdRequest { Uid = uid });
            if(response.Examresults.Count == 0)
            {
                return null;
            }
            var examResults = new List<ExamResultDto>();

            foreach (var grpcModel in response.Examresults)
            {
                var examResultDto = new ExamResultDto
                {
                    exam_result_id = grpcModel.ExamResultId,
                    uid = uid,
                    time_limit = grpcModel.TimeLimit,
                    exercise_id = grpcModel.ExerciseId,
                    title_of_exercise = grpcModel.TitleOfExercise,
                    score = grpcModel.Score,
                    total_score_listening = grpcModel.TotalScoreListening,
                    total_score_reading = grpcModel.TotalScoreReading,
                    total_right = grpcModel.TotalRight,
                    total_wrong = grpcModel.TotalWrong,
                    date = grpcModel.Date,
                    category_detail_name = grpcModel.CategoryDetailName,
                    category_name = grpcModel.CategoryName,                  
                };

                examResults.Add(examResultDto);
            }

            return examResults;
           
        }

        public async Task<GetUserDto> UpdateUser(string uid, UpdateUserDto updateUserDto)
        {
            if (string.IsNullOrEmpty(uid) || updateUserDto == null)
            {
                
                throw new ArgumentException("Invalid uid or updateUserDto");
            }

            try
            {
                if (updateUserDto.avatarFile != null)
                {
                    var avatarUrl = await _fileService.SaveFile(updateUserDto.avatarFile);
                    updateUserDto.avatar = avatarUrl;
                    await _userRepository.UpdateUserAsync(uid, updateUserDto);
                }
                else
                {
                    await _userRepository.UpdateUserAsync(uid, updateUserDto);
                }
                return await _userRepository.GetUserByIdAsync(uid);

            }
            catch (Exception ex)
            {                
                return null; 
            }
        }

        public async Task<ResultResponse> DeleteUser(string uid)
        {
            if(await _userRepository.DeleteUserAsync(uid) == true)            
                return new ResultResponse { StatusCode = 200, StatusDetail = "Delele User Success" };
            else
                return new ResultResponse { StatusCode = 404, StatusDetail = "User Not Found" };
        }

        public async Task<ResultResponse> DeleteExamResult(string examResultId)
        {
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var response = client.DeleteExamResult(new DeleteExamResultRequest { ExamResultId = examResultId });
            return await Task.FromResult(new ResultResponse
            {
                StatusCode = response.Status,
            });
        }

        public async Task<GetExamResultDto> GetExamResultsById(string examResultId)
        {
            if (string.IsNullOrEmpty(examResultId))
            {
                throw new ArgumentException("Please provide valid uid");
            }
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var response = client.GetExamResultsById(new GetExamResultsByIdRequest { ExamResultId = examResultId });
            if (string.IsNullOrEmpty(response.ExamResultId))
            {
                return null;
            }
            var examResultDetails = new List<GetExamResultDetailDto>();

            foreach (var grpcModel in response.Examresultdetails)
            {
                var erdDto = new GetExamResultDetailDto
                {
                    question_id = grpcModel.QuestionId,
                    question_content = grpcModel.QuestionContent,
                    corect_answer = grpcModel.CorectAnswer,
                    answer_of_user = grpcModel.AnswerOfUser,
                    answer_explanation = grpcModel.AnswerExplanation
                };
                examResultDetails.Add(erdDto);
            }

            return await Task.FromResult( new GetExamResultDto
            {
                exam_result_id = examResultId,
                uid = response.Uid,
                time_limit = response.TimeLimit,
                title_of_exercise = response.TitleOfExercise,
                exercise_id = response.ExerciseId,
                score = response.Score,
                total_score_listening = response.TotalScoreListening,
                total_score_reading = response.TotalScoreReading,
                total_right = response.TotalRight,
                total_wrong = response.TotalWrong,
                date =response.Date,
                exam_result_details = examResultDetails
            });
        }

        public async Task<GetExamResultDto> GetExamResultsByExerciseIdAndUid(string exerciseId,string uid)
        {
            if (string.IsNullOrEmpty(exerciseId))
            {
                throw new ArgumentException("Please provide valid uid");
            }
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var response = client.GetExamResultsByExerciseIdAndUid(new GetExamResultsByExerciseIdAndUidResquest { ExerciseId = exerciseId, Uid = uid });
            var examResultDetails = new List<GetExamResultDetailDto>();
            if (string.IsNullOrEmpty(response.ExamResultId))
            {
                return null;
            }
            foreach (var grpcModel in response.Examresultdetails)
            {
                var erdDto = new GetExamResultDetailDto
                {
                    question_id = grpcModel.QuestionId,
                    question_content = grpcModel.QuestionContent,
                    corect_answer = grpcModel.CorectAnswer,
                    answer_of_user = grpcModel.AnswerOfUser,
                    answer_explanation = grpcModel.AnswerExplanation
                };
                examResultDetails.Add(erdDto);
            }

            return await Task.FromResult(new GetExamResultDto
            {
                exam_result_id = response.ExamResultId,
                uid = response.Uid,
                time_limit = response.TimeLimit,
                title_of_exercise = response.TitleOfExercise,
                exercise_id = response.ExerciseId,
                score = response.Score,
                total_score_listening = response.TotalScoreListening,
                total_score_reading = response.TotalScoreReading,
                total_right = response.TotalRight,
                total_wrong = response.TotalWrong,
                date = response.Date,
                exam_result_details = examResultDetails
            });
        }

        public async Task<List<GetAverageExamResultPerDayDto>> GetExamResultsFromTimeRangeByUserId(string uid, string from, string? to )
        {
            if (string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("Please provide valid uid");
            }
            if (string.IsNullOrEmpty(to))
            {
                to = "currentdate";
            }
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var response = client.GetExamResultsFromTimeRangeByUserId(new GetExamResultsFromTimeRangeByUserIdRequest { Uid = uid,From= from, To=to  });
            if (response.Examresultsperday.Count == 0)
            {
                return null;
            }
            var examResults = new List<GetAverageExamResultPerDayDto>();

            foreach (var grpcModel in response.Examresultsperday)
            {
                var examResultDto = new GetAverageExamResultPerDayDto
                {
                    date = grpcModel.Date,
                   averageScorePerDate = grpcModel.AvarageScore,
                };

                examResults.Add(examResultDto);
            }

            return examResults;
        }

        public async Task<ResultResponse> DeleteExamResults(List<string> examResultIds)
        {
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_exerciseChannel);
            var ids = new List<DeleteExamResultRequest>();
            foreach (var id in examResultIds)
            {
                ids.Add(new DeleteExamResultRequest { ExamResultId = id });
            }
            var req = new DeleteExamResultsRequest { ExamResultIds = { ids } };
            var response = await client.DeleteExamResultsAsync(req);
            return  new ResultResponse
            {
                StatusCode = response.Status,              
            };
        }

    }
}
