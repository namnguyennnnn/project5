
using ExercisesApi.DTO;
using ExercisesApi.Repository.AnswerRepo;
using ExercisesApi.Repository.ExerciseRepo;
using ExercisesApi.Repository.QuestionRepo;
using ExercisesApi.Model;
using ExercisesApi.Services.ImageService;
using ExercisesApi.Services.AudioService;
using ExercisesApi.Repository.AudioRepo;
using ExercisesApi.Repository.ImageRepo;
using Grpc.Net.Client;
using PythonPakage;
using CatagoryDetailsManagement;
using ExercisesApi.Data;
using ExercisesApi.DTO.examResponse;
using System.Diagnostics;

namespace ExercisesApi.Services.ExerciseService
{
    public class ExerciseServices : IExerciseServices
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IImageService _imageService;
        private readonly IAudioService _audioService;
        private readonly IAudioRepository _audioRepository;
        private readonly IImageRepository _imageRepository;
        private readonly GrpcChannel _channelAudio;
        private readonly GrpcChannel _channelCategory;

        public ExerciseServices(IImageRepository imageRepository,
            IAudioRepository audioRepository,
            IAudioService audioService,
            IExerciseRepository exerciseRepository,
            IAnswerRepository answerRepository,
            IQuestionRepository questionRepository,
            IImageService imageService
            )
        {
            _exerciseRepository = exerciseRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _imageService = imageService;
            _audioService = audioService;
            _audioRepository = audioRepository;
            _imageRepository = imageRepository;
            
            _channelAudio = GrpcChannelManager.AudioChannel;
            _channelCategory = GrpcChannelManager.CategoryChannel;
        }

        public async Task<StatusResponse> CreateExercise(CreateExerciseRequestDto exerciseRequestDto)
        {
            if (exerciseRequestDto == null)
            {
                throw new ArgumentNullException(nameof(exerciseRequestDto));
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // Start measuring time
            try 
            {
                
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                var newExercise = new Exercise
                {
                    exercise_id = Guid.NewGuid().ToString(),
                    title_of_exercise = exerciseRequestDto.title_of_exercise,
                    exercise_description = exerciseRequestDto.exercise_description,
                    category_detail_id = exerciseRequestDto.category_detail_id,
                    create_at = localTime
                };

                await _exerciseRepository.AddExerciseAsync(newExercise);

                if (exerciseRequestDto.questionDtos != null && exerciseRequestDto.answerDtos != null
                    && exerciseRequestDto.questionDtos.Count == exerciseRequestDto.answerDtos.Count)
                {
                    // Parallel processing for inserting questions and answers
                    var insertTasks = new List<Task>();
                    for (int i = 0; i < exerciseRequestDto.questionDtos.Count; i++)
                    {
                        var questionDto = exerciseRequestDto.questionDtos[i];
                        var answerDto = exerciseRequestDto.answerDtos[i];

                        var questionId = await InsertQuestionAsync(newExercise, questionDto);
                        await InsertAnswerAsync(questionId, answerDto);

                        if (exerciseRequestDto.image_url != null && exerciseRequestDto.image_url.Count > i)
                        {
                            var imageUrl = exerciseRequestDto.image_url[i];
                            await InsertImageAsync(imageUrl, questionId);
                        }
                    }

                    await Task.WhenAll(insertTasks);
                }

                if (exerciseRequestDto.audioDto != null)
                {
                    await _audioService.CreateAudio(exerciseRequestDto.audioDto, newExercise.exercise_id);
                }
                else
                {
                    throw new Exception("null rồi");
                }

                return new StatusResponse
                {
                    StatusCode = 200,
                    StatusDetail = "Success"
                };
            }
            finally
            {
                stopwatch.Stop(); // Stop measuring time
                TimeSpan elapsed = stopwatch.Elapsed;

                // Log or print the elapsed time
                Console.WriteLine($"CreateExercise took {elapsed.TotalSeconds} seconds");
            }
        }
        //---------for get exam functon----------
        private async Task<string> InsertQuestionAsync(Exercise newExercise, CreateQuestionDto questionDto)
        {
            var newQuestion = new Question
            {
                question_id = Guid.NewGuid().ToString(),
                question_content = questionDto.question_content,
                index = questionDto.index,
                paragraph = questionDto.paragraph,
                exercise_id = newExercise.exercise_id,
            };

            await _questionRepository.AddQuestionAsync(newQuestion);

            // Return the newly generated question ID
            return newQuestion.question_id;
        }


        private async Task InsertAnswerAsync(string questionId, CreateAnswerDto answerDto)
        {
            var newAnswer = new Answer
            {
                answer_id = Guid.NewGuid().ToString(),
                answer_explanation = answerDto.answer_explanation,
                a = answerDto.a,
                b = answerDto.b,
                c = answerDto.c,
                d = answerDto.d,
                corect_answer = answerDto.corect_answer,
                question_id = questionId
            };

            await _answerRepository.AddAnswerAsync(newAnswer);
        }

        private async Task InsertImageAsync(IFormFile imageUrl, string questionId)
        {
            await _imageService.CreateImage(imageUrl, questionId);
        }


        public async Task<ExamResponse> GetExamAsync(string exerciseId, List<int>? parts = null)
        {

            var result = new ExamResponse();
            var questionresponse = new Dictionary<string, List<QuestionDto>>();
            var audioInfo = new InfoAudioToTrim();
            var exercise = await _exerciseRepository.GetExamByIdExerciseAsync(exerciseId);
            var audio = await _audioRepository.GetAudioByExerciseIdAsync(exerciseId);
            var infoCategoryDetail = await GetCategoryInfo(exercise.category_detail_id);
            if (exercise != null)
            {
                if (parts == null || parts.Count == 0)
                {
                    parts = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
                }

                var timeRange = new List<string>();

                foreach (var part in parts)
                {
                    var partQuestions = exercise.questions
                        .Where(q => (q.index >= GetStartIndexForPart(part) && q.index <= GetEndIndexForPart(part)))
                        .Select(q => new QuestionDto
                        {
                            question_id = q.question_id,
                            question_content = q.question_content,
                            index = q.index,
                            paragraph = q.paragraph,
                            corect_answer = q.answer.corect_answer,
                            image_url = q.image != null ? q.image.image_url : null,
                            answer_explanation = q.answer.answer_explanation,
                            answer = new AnswerDto
                            {
                                a = q.answer.a,
                                b = q.answer.b,
                                c = q.answer.c,
                                d = q.answer.d,
                            }
                        })
                        .OrderBy(q => q.index)
                        .ToList();

                    questionresponse.Add($"part-{part}", partQuestions);

                }

                var partResponse = new PartResponse
                {
                    exercise_id = exercise.exercise_id,
                    exercise_description = exercise.exercise_description,
                    title_of_exercise = exercise.title_of_exercise,
                    category_detail_name = infoCategoryDetail.category_detail_name,
                    category_name = infoCategoryDetail.category_name,
                    question = questionresponse
                };
                if (parts.Contains(1))
                {
                    timeRange.Add(audio.part1);
                }
                if (parts.Contains(2))
                {
                    timeRange.Add(audio.part2);
                }
                if (parts.Contains(3))
                {
                    timeRange.Add(audio.part3);
                }
                if (parts.Contains(4))
                {
                    timeRange.Add(audio.part4);
                }
                if (timeRange.Count > 0)
                {
                     audioInfo = new InfoAudioToTrim
                    {
                        AudioUrl = audio.audio_url,
                        TimeRange = timeRange
                    };
                   
                }           

                result = new ExamResponse
                {
                    exercise = partResponse,
                    audio = audioInfo
                };
            }
            
            return result;
        }
        //-----------------------------------------

        public async Task<byte[]> GetAudioAsync(string url, List<string> timeRange)
        {
            var rs = await GetDataAudio(url, timeRange);
            return rs;                     
        }

        public async Task<StatusResponse> UpdateExercise(string exerciseId, ExerciseUpdateRequest exerciseModel)
        {
            if (exerciseModel == null)
            {
                throw new ArgumentNullException(nameof(exerciseModel));
            }
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId);
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise));
            }

            exercise.title_of_exercise = exerciseModel.title_of_exercise;
            exercise.exercise_description = exerciseModel.exercise_description;
            exercise.category_detail_id = exerciseModel.category_detail_id;
            exercise.create_at = localTime;

            await _exerciseRepository.UpdateExerciseAsync(exercise);
            return new StatusResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }

        public async Task<StatusResponse> DeleteExercise(string exerciseId)
        {
            if (exerciseId == null)
            {
                throw new ArgumentNullException(nameof(exerciseId));
            }
            await _exerciseRepository.DeleteExerciseAsync(exerciseId);
            return new StatusResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }

        public  async Task<List<ExerciseInfo>> GetListExercise(string categoryDetailId)
        {
            var exercises = await _exerciseRepository.GetExercisesByCategoryDetailIdAsync(categoryDetailId);
            return exercises;
        }
        private async Task<PartResponse> GetCategoryInfo(string categoryDetailId)
        {
            if (categoryDetailId == null)
            {
                throw new Exception(nameof(categoryDetailId));
            }
            var client = new CatagoryDetailsManagement.CatagoryDetailManager.CatagoryDetailManagerClient(_channelCategory);
            var response = client.GetCatagoryDetailInFor(new GetCatagoryDetailInForRequest { CategoryDetailId = categoryDetailId });
            return new PartResponse
            {

                category_detail_name = response.CategoryDetailName,
                category_name = response.CategoryName,
            };

        }
        private async Task<byte[]> GetAudio(string url, string time)
        {
            var client = new PythonPakage.PythonAudioService.PythonAudioServiceClient(_channelAudio);
            var response = client.Trimaudio(new TrimaudioRequest { AudioUrl = url, Time = time });

            return await Task.FromResult(response.AudioData.ToByteArray());
        }

        private int GetEndIndexForPart(int part)
        {
            switch (part)
            {
                case 1: return 6;
                case 2: return 31;
                case 3: return 69;
                case 4: return 100;
                case 5: return 130;
                case 6: return 146;
                case 7: return 200;
                default: return 0;
            }
        }

        private int GetStartIndexForPart(int part)
        {
            switch (part)
            {
                case 1: return 1;
                case 2: return 7;
                case 3: return 32;
                case 4: return 70;
                case 5: return 101;
                case 6: return 131;
                case 7: return 147;
                default: return 0;
            }
        }
        private async Task<byte[]> Merge2Audio(string url, string time1, string time2)
        {

            var client = new PythonPakage.PythonAudioService.PythonAudioServiceClient(_channelAudio);

            var response = client.Merge2Audio(new MergeAudio2Request { AudioUrl = url, Time1 = time1, Time2 = time2 });
            return await Task.FromResult(response.AudioData.ToByteArray());

        }

        private async Task<byte[]> Merge3Audio(string url, string time1, string time2, string time3)
        {

            var client = new PythonPakage.PythonAudioService.PythonAudioServiceClient(_channelAudio);

            var response = client.Merge3Audio(new MergeAudio3Request { AudioUrl = url, Time1 = time1, Time2 = time2, Time3 = time3 });
            return await Task.FromResult(response.AudioData.ToByteArray());

        }
        private async Task<byte[]> GetDataAudio(string url, List<string> timeRange)
        {
            if (timeRange.Count == 4)
            {
                return await GetAudio(url, "full");
            }
            else if (timeRange.Count == 3)
            {
                return await Merge3Audio(url, timeRange[0], timeRange[1], timeRange[2]);
            }
            else if (timeRange.Count == 2)
            {
                return await Merge2Audio(url, timeRange[0], timeRange[1]);
            }
            else if (timeRange.Count == 1)
            {
                return await GetAudio(url, timeRange[0]);
            }
            else
            {
                return null;
            }

        }

      
    }
}
