
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
using ExercisesApi.DTO.examResponse;
using System.Diagnostics;
using ExercisesApi.Services.FileService;
using ExercisesApi.Repository.ParagraphRepo;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using UserManagement;
using ExercisesApi.Repository.ExamResultRepo;
using ExercisesApi.Repository.ExamResultDetailRepo;
using ExercisesApi.DTO.GetDataExerciseFromExcelDto;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using ExercisesApi.Services.ParagraphService;

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
        private readonly GrpcChannel _channelUser;
        private readonly IFileService _fileService;
        private readonly IParagraphRepository _paragraphRepository;
        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamResultDetailRepository _examResultDetailRepository;
        private readonly IParagraphService _paragraphService;

        public ExerciseServices(IImageRepository imageRepository,
            IAudioRepository audioRepository,
            IExerciseRepository exerciseRepository,
            IAnswerRepository answerRepository,
            IQuestionRepository questionRepository,
            IParagraphRepository paragraphRepository,
            IAudioService audioService,
            IImageService imageService,
            IFileService fileService,
            IExamResultRepository examResultRepository,
            IExamResultDetailRepository examResultDetailRepository,
            IParagraphService paragraphService
            )
        {
            _exerciseRepository = exerciseRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _paragraphRepository = paragraphRepository;
            _imageService = imageService;
            _audioService = audioService;
            _audioRepository = audioRepository;
            _imageRepository = imageRepository;
            _fileService = fileService;
            _channelAudio = GrpcChannelManager.AudioChannel;
            _channelCategory = GrpcChannelManager.CategoryChannel;
            _channelUser = GrpcChannelManager.UserChannel;
            _examResultDetailRepository = examResultDetailRepository;
            _examResultRepository = examResultRepository;
            _paragraphService = paragraphService;
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
                    create_at = localTime.ToString()
                };

                await _exerciseRepository.AddExerciseAsync(newExercise);

                var questionBatch = new List<Question>();
                var answerBatch = new List<Answer>();
                var imageBatch = new List<Image>();
                var paragraphBatch = new List<Paragraph>();

                if (exerciseRequestDto.questionDtos != null)
                {
                    for (int i = 0; i < exerciseRequestDto.questionDtos.Count; i++)
                    {
                        var questionDto = exerciseRequestDto.questionDtos[i];

                        var questionId = Guid.NewGuid().ToString();

                        var newQuestion = new Question
                        {
                            question_id = questionId,
                            question_content = questionDto.question_content,
                            index = questionDto.index ?? 0,
                            exercise_id = newExercise.exercise_id,
                        };

                        questionBatch.Add(newQuestion);

                        var newAnswer = new Answer
                        {
                            answer_id = Guid.NewGuid().ToString(),
                            answer_explanation = questionDto.answer.answer_explanation,
                            a = questionDto.answer.a,
                            b = questionDto.answer.b,
                            c = questionDto.answer.c,
                            d = questionDto.answer.d,
                            corect_answer = questionDto.answer.corect_answer,
                            question_id = questionId
                        };

                        answerBatch.Add(newAnswer);

                        if (exerciseRequestDto.imageDto != null && !exerciseRequestDto.imageDto.Any(i => i.imageFile == null))
                        {
                            var imageDto = exerciseRequestDto.imageDto.FirstOrDefault(img => img.questionIndex == questionDto.index);
                            if (imageDto != null)
                            {
                                var newImage = await _imageService.CreateImage(imageDto.imageFile, newQuestion.question_id);
                                imageBatch.Add(newImage);
                            }

                        }
                        else
                        {
                            throw new ArgumentNullException("ImageFile null");
                        }

                        if (exerciseRequestDto.paragraphDto != null && !exerciseRequestDto.paragraphDto.Any(p => p.paragraphFile == null))
                        {
                            var paragraphDto = exerciseRequestDto.paragraphDto.FirstOrDefault(paragraph => paragraph.questionIndex == questionDto.index);
                            if (paragraphDto != null)
                            {
                                var newParagraph = await _paragraphService.CreateParagraph(paragraphDto.paragraphFile, newQuestion.question_id);
                                paragraphBatch.Add(newParagraph);
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("ParagraphFile null");
                        }
                    }
                }

                await _questionRepository.AddQuestionsAsync(questionBatch);
                await _answerRepository.AddAnswersAsync(answerBatch);
                if (imageBatch.Count > 0)
                {
                    await _imageRepository.AddImagesAsync(imageBatch);
                }
                if (paragraphBatch.Count > 0)
                {
                    await _paragraphRepository.AddParagraphsAsync(paragraphBatch);
                }

                if (exerciseRequestDto.audioDto != null)
                {
                    await _audioService.CreateAudio(exerciseRequestDto.audioDto, newExercise.exercise_id);
                }
                else
                {
                    return new StatusResponse
                    {
                        StatusCode = 400,
                        StatusDetail = "Audio Null"
                    };
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

                Console.WriteLine($"CreateExercise took {elapsed.TotalSeconds} seconds");
            }
        }
        public async Task<StatusResponse> CreateExerciseByExcelFile(IFormFile excelFile, IFormFile audiofile)
        {
           if (excelFile == null|| audiofile == null) 
            {
                throw new ArgumentNullException("Please submit data");
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start(); // Start measuring time        

            try
            {
                var dataExercise = await GetDataFromExcel(excelFile);
                var questionBatch = new List<Question>();
                var answerBatch = new List<Answer>();
                var imageBatch = new List<Image>();
                var paragraphBatch = new List<Paragraph>();
                if (dataExercise != null)
                {
                    var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                    var newExercise = new Exercise
                    {
                        exercise_id = Guid.NewGuid().ToString(),
                        title_of_exercise = dataExercise.exercisedto.title_of_exercise,
                        exercise_description = dataExercise.exercisedto.exercise_description,
                        category_detail_id = dataExercise.exercisedto.category_detail_id,
                        create_at = localTime.ToString()
                    };

                    if (dataExercise.questionDtos !=null)
                    {

                        foreach (var questionAndAnswer in dataExercise.questionDtos)
                        {
                            var questionId = Guid.NewGuid().ToString();
                            var newQuestion = new Question
                            {
                                question_id = questionId,
                                question_content = questionAndAnswer.question_content,
                                index = questionAndAnswer.index ?? 0,
                                exercise_id = newExercise.exercise_id,
                            };
                            questionBatch.Add(newQuestion);

                            var newAnswer = new Answer
                            {
                                answer_id = Guid.NewGuid().ToString(),
                                answer_explanation = questionAndAnswer.answer_explanation,
                                a = questionAndAnswer.a,
                                b = questionAndAnswer.b,
                                c = questionAndAnswer.c,
                                d = questionAndAnswer.d,
                                corect_answer = questionAndAnswer.corect_answer,
                                question_id = questionId
                            };

                            answerBatch.Add(newAnswer);

                            if (dataExercise.imagesDatas != null && !dataExercise.imagesDatas.Any(i => i.dataImage == null))
                            {
                                var imageDto = dataExercise.imagesDatas.FirstOrDefault(img => img.questionIndex == questionAndAnswer.index);
                                if (imageDto != null)
                                {
                                    var newImage = await _imageService.CreateImageByData(imageDto.dataImage, newQuestion.question_id);
                                    imageBatch.Add(newImage);
                                }

                            }
                            else
                            {
                                throw new ArgumentNullException("ImageFile null");
                            }
                            if (dataExercise.paragraphsDatas != null && !dataExercise.paragraphsDatas.Any(p => p.dataParagraph == null))
                            {
                                var paragraphDto = dataExercise.paragraphsDatas.FirstOrDefault(paragraph => paragraph.questionIndex == questionAndAnswer.index);
                                if (paragraphDto != null)
                                {
                                    var newParagraph = await _paragraphService.CreateParagraphByData(paragraphDto.dataParagraph, newQuestion.question_id);
                                    paragraphBatch.Add(newParagraph);
                                }
                            }
                            else
                            {
                                throw new ArgumentNullException("ParagraphFile null");
                            }
                        }
                        await _exerciseRepository.AddExerciseAsync(newExercise);
                        await _questionRepository.AddQuestionsAsync(questionBatch);
                        await _answerRepository.AddAnswersAsync(answerBatch);

                        if (imageBatch.Count > 0)
                        {
                            await _imageRepository.AddImagesAsync(imageBatch);
                        }
                        if (paragraphBatch.Count > 0)
                        {
                            await _paragraphRepository.AddParagraphsAsync(paragraphBatch);
                        }
                        if (audiofile != null)
                        {
                            var newAudio = new CreateAudioDto
                            {
                                audioFile = audiofile,
                                part1 = dataExercise.audiodto.part1,
                                part2 = dataExercise.audiodto.part2,
                                part3 = dataExercise.audiodto.part3,
                                part4 = dataExercise.audiodto.part4,
                            };
                            await _audioService.CreateAudio(newAudio, newExercise.exercise_id);
                        }

                        else
                        {
                            return new StatusResponse
                            {
                                StatusCode = 400,
                                StatusDetail = "Audio Null"
                            };
                        }

                        return new StatusResponse
                        {
                            StatusCode = 200,
                            StatusDetail = "Success"
                        };

                    }
                    else
                    {
                        throw new ArgumentNullException("Question null");
                    }
                  
                }
                else
                {
                    throw new ArgumentNullException("Can't read data in excel file");
                }
            }
            finally
            {
                stopwatch.Stop(); // Stop measuring time
                TimeSpan elapsed = stopwatch.Elapsed;

                Console.WriteLine($"CreateExercise took {elapsed.TotalSeconds} seconds");
            }
           
        }
        public async Task<GetExamResultDto> GradeTheExam(string exerciseId, string uid, List<AnswerOfUserDto> answersOfUser, string timeLimit)
        {

            if (string.IsNullOrEmpty(exerciseId) || string.IsNullOrEmpty(uid) || answersOfUser == null || answersOfUser.Count == 0 || string.IsNullOrEmpty(timeLimit))
            {
                throw new ArgumentException("Invalid input parameters.");
            }

            var examQuestionAndAnswer = await _questionRepository.GetQuestionsByExerciseIdAsync(exerciseId);

            var examResultDetailsBatch = new List<CreateExamResultDetailDto>();
            var listeningCount = 0;
            var readingCount = 0;
            var newExamResult = new CreateExamResultDto
            {
                exam_result_id = Guid.NewGuid().ToString(),
                exercise_id = exerciseId,
                uid = uid,
                time_limit = timeLimit,
                date = DateOnly.FromDateTime(DateTime.Now).ToString(),
                total_score_listening= 0,
                total_score_reading = 0,
                total_right = 0,
                total_wrong = 0
            };

            foreach (var answer in answersOfUser)
            {
                var question = examQuestionAndAnswer.FirstOrDefault(q => q.index == answer.questionIndex);

                if (question != null)
                {
                    bool isCorrect = string.Equals(question.corect_answer.Trim(), answer.selected_answer.Trim(), StringComparison.OrdinalIgnoreCase);

                    if (question.index >= 1 && question.index <= 100)
                    {
                        if (isCorrect == true)
                        {
                            listeningCount++;
                        }

                    }
                    else if (question.index >= 101 && question.index <= 200)
                    {
                        if (isCorrect == true)
                        {
                            readingCount++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("nhiều câu hỏi quá z");
                    }

                    var newExamResultDetail = new CreateExamResultDetailDto
                    {
                        exam_result_detail_id = Guid.NewGuid().ToString(),
                        exam_result_id = newExamResult.exam_result_id,
                        answer_of_user = answer.selected_answer,
                        question_id = question.question_id
                    };
                    examResultDetailsBatch.Add(newExamResultDetail);
                }
            }

            var listeningBaseScore = 15;
            var additionalListeningScore = (listeningCount - 1) * 5;
            var listeningScore = Math.Min(listeningBaseScore + additionalListeningScore, 495);
            if (listeningCount == 0)
            {
                listeningScore = 0;
            }

            var readingScore = 0;
            if (readingCount == 0 || readingCount < 0)
            {
                readingScore = 0;
            }
            else 
            {
                readingScore = readingCount * 5;
                readingScore = Math.Min(readingScore, 495);
            }
      
            newExamResult.score = listeningScore + readingScore;
            newExamResult.total_score_listening = listeningScore;
            newExamResult.total_score_reading = readingScore;
            newExamResult.total_right = readingCount + listeningCount;
            newExamResult.total_wrong = 200 - (readingCount + listeningCount);
            try
            {
                await _examResultRepository.AddExamResultAsync(newExamResult);
                await _examResultDetailRepository.AddExamResultDetailsAsync(examResultDetailsBatch);
                var result = await _examResultRepository.GetExamResultByIdAsync(newExamResult.exam_result_id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save exam result and details.", ex);
            }

        }

        public async Task<ExamResponse> GetExamAsync(string exerciseId, List<int>? parts = null)
        {
            var partsSort = parts.OrderBy(x => x).ToList();
            var result = new ExamResponse();
            var questionresponse = new Dictionary<string, List<QuestionDto>>();
            var audioInfo = new InfoAudioToTrim();
            var exercise = await _exerciseRepository.GetExamByIdExerciseAsync(exerciseId);
            var audio = await _audioRepository.GetAudioByExerciseIdAsync(exerciseId);
            var infoCategoryDetail = await GetCategoryInfo(exercise.category_detail_id);
            if (infoCategoryDetail == null)
            {
                throw new Exception("Category doesn't exist");
            }
            if (exercise != null)
            {
                if (partsSort == null || partsSort.Count == 0)
                {
                    partsSort = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
                }

                var timeRange = new List<string>();

                foreach (var part in partsSort)
                {
                    var partQuestions = (await Task.WhenAll(exercise.questions
                        .Where(q => (q.index >= GetStartIndexForPart(part) && q.index <= GetEndIndexForPart(part)))
                        .Select(async q => new QuestionDto
                        {
                            question_id = q.question_id,
                            question_content = q.question_content,
                            index = q.index,
                            paragraph_url = q.paragraph != null ? await _fileService.GetSignedUrl(q.paragraph.paragraph_url) : null,
                            corect_answer = q.answer.corect_answer,
                            image_url = q.image != null ? await _fileService.GetSignedUrl(q.image.image_url) : null,
                            answer_explanation = q.answer.answer_explanation,
                            answer = new AnswerDto
                            {
                                a = q.answer.a,
                                b = q.answer.b,
                                c = q.answer.c,
                                d = q.answer.d,
                            }
                        }).ToList()
                        )).OrderBy(q => q.index).ToList();

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
                else if (parts.Contains(2))
                {
                    timeRange.Add(audio.part2);
                }
                else if (parts.Contains(3))
                {
                    timeRange.Add(audio.part3);
                }
                else if (parts.Contains(4))
                {
                    timeRange.Add(audio.part4);
                }
                else
                {
                    timeRange.Add("full");
                }
                if (timeRange.Count > 0)
                {
                    var linkAudio = await _fileService.GetSignedUrl(audio.audio_url);
                    audioInfo = new InfoAudioToTrim
                    {
                        AudioUrl = linkAudio,
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
        public async Task<byte[]> GetAudioAsync(string url, List<string> timeRange)
        {
            var rs = await GetDataAudio(url, timeRange);
            return rs;
        }
        public async Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId)
        {
            if (exerciseId == null)
            {
                throw new ArgumentNullException(nameof(exerciseId));
            }

            var exercise = await _exerciseRepository.GetExerciseByIdForUpdateAsync(exerciseId);
            return exercise;
        }
        public async Task<GetTotalCommentsResponse> GetExercises()
        {
            var exercises = await _exerciseRepository.GetExercisesAsync();

            if (exercises == null)
            {
                throw new ArgumentNullException(nameof(exercises));
            }

            var client = new UserManagement.UserManager.UserManagerClient(_channelUser);
            var request = new GetTotalCommentsRequest();
            foreach (var exercise in exercises)
            {
                var exerciseModelGrpc = new ExerciseModelGrpc
                {
                    ExerciseId = exercise.exercise_id,
                    CategoryDetailId = exercise.category_detail_id,
                    TitleOfExercise = exercise.title_of_exercise,
                    ExerciseDescription = exercise.exercise_description,
                    CreateAt = exercise.create_at
                };

                request.Exercises.Add(exerciseModelGrpc);
            }
            var response = await client.GetTotalCommentsAsync(request);

            return response;
        }
        public async Task<GetTotalCommentsResponse> GetExercisesByCategoryDetail(string categoryDetailId)
        {
            var exercises = await _exerciseRepository.GetExercisesByCategoryDetailIdAsync(categoryDetailId);
            if (exercises == null)
            {
                throw new ArgumentNullException(nameof(exercises));
            }
            var client = new UserManagement.UserManager.UserManagerClient(_channelUser);
            var request = new GetTotalCommentsRequest();
            foreach (var exercise in exercises)
            {
                var exerciseModelGrpc = new ExerciseModelGrpc
                {
                    ExerciseId = exercise.exercise_id,
                    CategoryDetailId = exercise.category_detail_id,
                    TitleOfExercise = exercise.title_of_exercise,
                    ExerciseDescription = exercise.exercise_description,
                    CreateAt = exercise.create_at
                };

                request.Exercises.Add(exerciseModelGrpc);
            }
            var response = await client.GetTotalCommentsAsync(request);

            return response;
        }


        public async Task<GetExerciseToUpdateDto> UpdateExamAsync(string exerciseId, CreateExerciseRequestDto requestDto)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                var exercise = await _exerciseRepository.GetExamByIdExerciseAsync(exerciseId);

                if (exercise == null)
                {
                    throw new ArgumentNullException(nameof(exercise));
                }
                List<CreateAnswerDto> answerBatchs = new List<CreateAnswerDto>();
                List<CreateImageDto> imageBatch = new List<CreateImageDto>();
                List<CreateParagraphDto> paragraphBatch = new List<CreateParagraphDto>();
                if (requestDto.exercise_description != null || requestDto.title_of_exercise != null || requestDto.category_detail_id != null)
                {
                    var exInfo = new ExerciseInfo
                    {
                        exercise_id = exerciseId,
                        title_of_exercise = requestDto.title_of_exercise ?? exercise.title_of_exercise,
                        exercise_description = requestDto.exercise_description ?? exercise.exercise_description,
                        category_detail_id = requestDto.category_detail_id ?? exercise.category_detail_id,
                        create_at = localTime.ToString(),
                    };

                    await _exerciseRepository.UpdateExerciseAsync(exInfo);
                }
                if (requestDto.questionDtos != null)
                {
                    await _questionRepository.UpdateQuestionAsync(requestDto.questionDtos);
                }

                if (requestDto.questionDtos != null)
                {
                    var questions = requestDto.questionDtos;
                    var answers = questions.Select(x => x.answer).ToList();
                    await _answerRepository.UpdateAnswerAsync(answers);
                }

                if (requestDto.imageDto != null)
                {
                    foreach (var image in requestDto.imageDto)
                    {
                        if (image.imageFile != null)
                        {
                            var fileUrl = await _fileService.UploadFileAsync(image.imageFile);
                            var imagefile = new CreateImageDto
                            {
                                image_id = image.image_id,
                                image_url = fileUrl,
                                question_id = image.question_id
                            };
                            imageBatch.Add(imagefile);
                        }
                        else
                        {
                            imageBatch.Add(image);
                        }
                    }
                    await _imageRepository.UpdateImagesAsync(imageBatch);
                }

                if (requestDto.paragraphDto != null)
                {
                    foreach (var paragraph in requestDto.paragraphDto)
                    {
                        if (paragraph.paragraphFile != null)
                        {
                            var fileUrl = await _fileService.UploadFileAsync(paragraph.paragraphFile);
                            var paragraphFile = new CreateParagraphDto
                            {
                                paragraph_id = paragraph.paragraph_id,
                                paragraph_url = fileUrl,
                                question_id = paragraph.question_id
                            };
                            paragraphBatch.Add(paragraphFile);
                        }
                        paragraphBatch.Add(paragraph);
                    }
                    await _paragraphRepository.UpdateParagraphsAsync(paragraphBatch);
                }

                if (requestDto.audioDto != null)
                {
                    var audio = requestDto.audioDto;
                    if (audio.audioFile != null)
                    {
                        var audioUrl = await _fileService.UploadFileAsync(audio.audioFile);
                        var audioInForFile = new CreateAudioDto
                        {
                            audio_id = audio.audio_id,
                            audio_url = audioUrl,
                            exercise_id = requestDto.audioDto.exercise_id,
                            part1 = requestDto.audioDto.part1,
                            part2 = requestDto.audioDto.part2,
                            part3 = requestDto.audioDto.part3,
                            part4 = requestDto.audioDto.part4,
                        };
                        await _audioRepository.UpdateAudioAsync(audioInForFile);
                    }
                    await _audioRepository.UpdateAudioAsync(requestDto.audioDto);
                }

                return await _exerciseRepository.GetExerciseByIdForUpdateAsync(exerciseId);
            }
            finally
            {

                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                Console.WriteLine($"CreateExercise took {elapsed.TotalSeconds} seconds");
            }


        }

        public async Task<StatusResponse> DeleteExercise(string exerciseId)
        {
            try
            {
                if (exerciseId == null)
                {
                    throw new ArgumentNullException(nameof(exerciseId));
                }
                var listUri = await _exerciseRepository.DeleteExerciseAsync(exerciseId);

                if (listUri != null)
                {
                    await _fileService.DeleteFilesAsync(listUri);
                }
                return new StatusResponse
                {
                    StatusCode = 200,
                    StatusDetail = "Success"
                };
            }
            catch (Exception ex)
            {

                return new StatusResponse
                {
                    StatusCode = 500,
                    StatusDetail = ex.Message
                };
            }
        }
        public async Task<StatusResponse> DeleteExercises(List<string> exerciseId)
        {
            if (exerciseId == null)
            {
                throw new ArgumentNullException(nameof(exerciseId));
            }
            await _exerciseRepository.DeleteExercisesAsync(exerciseId);
            return new StatusResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }

        private async Task<PartResponse> GetCategoryInfo(string categoryDetailId)
        {
            if (categoryDetailId == null)
            {
                throw new Exception(nameof(categoryDetailId));
            }
            var client = new CatagoryDetailsManagement.CatagoryDetailManager.CatagoryDetailManagerClient(_channelCategory);
            var response = client.GetCatagoryDetailInFor(new GetCatagoryDetailInForRequest { CategoryDetailId = categoryDetailId });
            if (string.IsNullOrEmpty(response.CategoryId))
            {
                return null;
            }
            return new PartResponse
            {
                category_detail_id = response.CategoryDetailId,
                category_detail_name = response.CategoryDetailName,
                category_name = response.CategoryName,
            };

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

        private async Task<byte[]> TrimAudio(string url, string time)
        {
            var client = new PythonPakage.PythonAudioService.PythonAudioServiceClient(_channelAudio);
            var response = client.Trimaudio(new TrimaudioRequest { AudioUrl = url, Time = time });

            return await Task.FromResult(response.AudioData.ToByteArray());
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
                return await TrimAudio(url, "full");
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
                return await TrimAudio(url, timeRange[0]);
            }
            else
            {
                return null;
            }

        }
       
        private async Task<ExcelCreateExerciseRequestDto> GetDataFromExcel(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var workbook = package.Workbook;


                    var exercisedto = new ExcelExerciseDto();
                    var questionDtos = new List<ExcelQuestionDto>();
                    var audiodto = new ExcelAudioDto();
                    var imagesDatas = new List<ExcelImagesDto>();
                    var paragraphsDatas = new List<ExcelParagraphDto>();

                    var imageDictionary = new Dictionary<string, byte[]>();
                    foreach (var worksheet in workbook.Worksheets)
                    {
                        if (worksheet.Name == "exercise")
                        {
                          
                            var startRow = 2;
                            var endRow = worksheet.Dimension.End.Row;
                            for (int row = startRow; row <= endRow; row++)
                            {
                                var exerciseWorksheetData = new Dictionary<string, string>();
                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    var cellValue = worksheet.Cells[row, col].Text;
                                    var headerValue = worksheet.Cells[1, col].Text;

                                    exerciseWorksheetData[headerValue] = cellValue;
                                }

                                var client = new CatagoryDetailsManagement.CatagoryDetailManager.CatagoryDetailManagerClient(_channelCategory);
                                var response = client.GetCatagoryDetailInForByName(new GetCatagoryDetailInForByNameRequest { CategoryDetailName = exerciseWorksheetData["Tên bộ đề thi"].Trim() });
                                exercisedto.title_of_exercise = exerciseWorksheetData["Tên đề thi"].Trim();
                                exercisedto.exercise_description = exerciseWorksheetData["Mô tả về đề thi"].Trim();
                                exercisedto.category_detail_id = response.CategoryDetailId;
                            }
                        }
                        else if (worksheet.Name == "question")
                        {
                            var questionWorksheetData = new List<Dictionary<string, string>>();

                            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                            {
                                var rowData = new Dictionary<string, string>();

                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    string headerValue = worksheet.Cells[1, col].Text;
                                    string cellValue = worksheet.Cells[row, col].Text;

                                    rowData[headerValue] = cellValue;
                                }
                                questionWorksheetData.Add(rowData);
                            }

                            foreach (var questionData in questionWorksheetData)
                            {
                                var questionDto = new ExcelQuestionDto
                                {                                  
                                    question_content = questionData["Nội dung câu hỏi"].Trim(),
                                    index = int.Parse(questionData["Số thứ tự"].Trim()),
                                    answer_explanation = questionData["Giải thích câu trả lời"].Trim(),
                                    a = questionData["Nội dung câu trả lời a"].Trim(),
                                    b = questionData["Nội dung câu trả lời b"].Trim(),
                                    c = questionData["Nội dung câu trả lời c"].Trim(),
                                    d = questionData["Nội dung câu trả lời d"].Trim(),
                                    corect_answer = questionData["Câu trả lời đúng"].Trim()
                                };


                                questionDtos.Add(questionDto);
                            }
                        }
                        else if (worksheet.Name == "audio")
                        {
                            var startRow = 2;
                            var endRow = worksheet.Dimension.End.Row;
                            for (int row = startRow; row <= endRow; row++)
                            {
                                var audioWorksheetData = new Dictionary<string, string>();
                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    var cellValue = worksheet.Cells[row, col].Text;
                                    var headerValue = worksheet.Cells[1, col].Text;

                                    audioWorksheetData[headerValue] = cellValue;
                                }
                                audiodto.part1 = audioWorksheetData["Khoảng gian của part 1"].Trim();
                                audiodto.part2 = audioWorksheetData["Khoảng gian của part 2"].Trim();
                                audiodto.part3 = audioWorksheetData["Khoảng gian của part 3"].Trim();
                                audiodto.part4 = audioWorksheetData["Khoảng gian của part 4"].Trim();
                            }

                        }
                        else
                        {
                            foreach (var image in worksheet.Drawings)
                            {
                                if (image is ExcelPicture)
                                {

                                    var picture = image as ExcelPicture;
                                    string imageName = picture.Name;
                                    imageDictionary[imageName] = picture.Image.ImageBytes;
                                    if (worksheet.Name.StartsWith("image"))
                                    {
                                        var imageDto = new ExcelImagesDto
                                        {
                                            questionIndex = await ExtractNumberFromString(imageName),
                                            dataImage = picture.Image.ImageBytes
                                        };

                                        imagesDatas.Add(imageDto);
                                    }
                                    else if (worksheet.Name.StartsWith("paragraph"))
                                    {

                                        var paragraphDto = new ExcelParagraphDto
                                        {
                                            questionIndex = await ExtractNumberFromString(imageName),
                                            dataParagraph = picture.Image.ImageBytes
                                        };
                                        paragraphsDatas.Add(paragraphDto);
                                    }
                                }
                            }

                        }
                    }
                  
                    return  new ExcelCreateExerciseRequestDto
                    {
                        exercisedto = exercisedto,
                        questionDtos = questionDtos,
                        paragraphsDatas = paragraphsDatas,
                        imagesDatas = imagesDatas,
                        audiodto = audiodto
                    }; ;
                }

            }

        }
        private async Task<int> ExtractNumberFromString(string input)
        {
            string numberString = string.Empty;
            bool foundDigit = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    numberString += c;
                    foundDigit = true;
                }
                else if (foundDigit)
                {
                    break;
                }
            }
            int result = 0;
            if (!string.IsNullOrEmpty(numberString))
            {
                int.TryParse(numberString, out result);
            }

            return await Task.FromResult(result);
        }

    }
}

