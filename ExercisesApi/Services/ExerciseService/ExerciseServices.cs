
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
using ExercisesApi.DTO.UpdateExerciseRequest;


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
        private readonly IFileService _fileService;
        private readonly IParagraphRepository _paragraphRepository;

        public ExerciseServices(IImageRepository imageRepository,
            IAudioRepository audioRepository,
            IAudioService audioService,
            IExerciseRepository exerciseRepository,
            IAnswerRepository answerRepository,
            IQuestionRepository questionRepository,
            IImageService imageService,
             IFileService fileService,
             IParagraphRepository paragraphRepository
            )
        {
            _exerciseRepository = exerciseRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _imageService = imageService;
            _audioService = audioService;
            _audioRepository = audioRepository;
            _imageRepository = imageRepository;
            _fileService = fileService;
            _channelAudio = GrpcChannelManager.AudioChannel;
            _channelCategory = GrpcChannelManager.CategoryChannel;
            _paragraphRepository = paragraphRepository;
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

                var questionBatch = new List<Question>();
                var answerBatch = new List<Answer>();
                var imageBatch = new List<Image>();
                var paragraphBatch = new List<Paragraph>();

                if (exerciseRequestDto.questionDtos != null )
                {
                                 

                    for (int i = 0; i < exerciseRequestDto.questionDtos.Count; i++)
                    {
                        var questionDto = exerciseRequestDto.questionDtos[i];
                       
                        var questionId = Guid.NewGuid().ToString();

                        var newQuestion = new Question
                        {
                            question_id = questionId,
                            question_content = questionDto.question_content,
                            index = questionDto.index,
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
                        var imageDto = exerciseRequestDto.imageDto.FirstOrDefault(img => img.questionIndex == questionDto.index);
                        var paragraphDto = exerciseRequestDto.paragraphDto.FirstOrDefault(paragraph => paragraph.questionIndex == questionDto.index);

                        if (imageDto != null)
                        {
                            var newImage = await _imageService.CreateImage(imageDto.imageFile, newQuestion.question_id);
                            imageBatch.Add(newImage);
                        }

                        if (paragraphDto != null)
                        {
                            var newParagraph = await CreateParagraph(paragraphDto.paragrahpFile, newQuestion.question_id);
                            paragraphBatch.Add(newParagraph);
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
                    throw new Exception("Audio data is null.");
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

        private async Task<Paragraph> CreateParagraph(IFormFile url, string questionId)
        {
            var filePath = await _fileService.SaveFile(url);
            return new Paragraph
            {
                paragraph_id = Guid.NewGuid().ToString(),
                paragraph_url = filePath,
                question_id = questionId
            };
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
            if (exercise != null)
            {
                if (partsSort == null || partsSort.Count == 0)
                {
                    partsSort = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
                }

                var timeRange = new List<string>();

                foreach (var part in partsSort)
                {
                    var partQuestions = exercise.questions
                        .Where(q => (q.index >= GetStartIndexForPart(part) && q.index <= GetEndIndexForPart(part)))
                        .Select(q => new QuestionDto
                        {
                            question_id = q.question_id,
                            question_content = q.question_content,
                            index = q.index,
                            paragraph_url = q.paragraph != null ? q.paragraph.paragraph_url: null,
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
     
        public async Task<byte[]> GetAudioAsync(string url, List<string> timeRange)
        {
            var rs = await GetDataAudio(url, timeRange);
            return rs;                     
        }
        
        public async Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId ) 
        {
            if (exerciseId == null)
            {
                throw new ArgumentNullException(nameof(exerciseId));
            }

            var exercise = await _exerciseRepository.GetExerciseByIdForUpdateAsync(exerciseId);

            return exercise;
        }

        public async Task<GetExerciseToUpdateDto> UpdateExamAsync(string exerciseId, UpdateExerciseRequestDto requestDto)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // Start measuring time        
            try 
            {
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                var exercise = await _exerciseRepository.GetExamByIdExerciseAsync(exerciseId);
                
                if (exercise == null)
                {
                    throw new ArgumentNullException(nameof(exercise));
                }
                
                List<UpdateImageDto> imageBatch = new List<UpdateImageDto>();
                List<UpdateParagraphDto> paragraphBatch = new List<UpdateParagraphDto>();
                if (requestDto.exerciseToUpdateDto != null)
                {
                    var exInfo = new ExerciseInfo
                    {
                        exercise_id = exerciseId,
                        title_of_exercise = requestDto.exerciseToUpdateDto.title_of_exercise,
                        exercise_description = requestDto.exerciseToUpdateDto.exercise_description,
                        category_detail_id = requestDto.exerciseToUpdateDto.category_detail_id,
                        create_at = localTime.ToString(),
                    };

                    await _exerciseRepository.UpdateExerciseAsync(exInfo);
                }
                if (requestDto.questionToUpdateDto != null)
                {                 
                    await _questionRepository.UpdateQuestionAsync(requestDto.questionToUpdateDto);
                }

                if (requestDto.answerToUpdateDto != null)
                {
                    await _answerRepository.UpdateAnswerAsync(requestDto.answerToUpdateDto);
                }

                if (requestDto.imageToUpdateDto != null)
                {
                    foreach (var image in requestDto.imageToUpdateDto)
                    {
                        if (image.imageFile != null)
                        {
                            var fileUrl = await _fileService.SaveFile(image.imageFile);
                            var imagefile = new UpdateImageDto
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

                if (requestDto.paragraphToUpdateDto != null)
                {
                    foreach (var paragraph in requestDto.paragraphToUpdateDto)
                    {
                        if (paragraph.paragraphFile != null)
                        {
                            var fileUrl = await _fileService.SaveFile(paragraph.paragraphFile);
                            var paragraphFile = new UpdateParagraphDto
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

                if (requestDto.audioToUpdateDto != null)
                {
                    var audio = requestDto.audioToUpdateDto;
                    if (audio.audioFile != null)
                    {
                        var audioUrl = await _fileService.SaveFile(audio.audioFile);
                        var audioInForFile = new UpdateAudioDto
                        {
                            audio_id = audio.audio_id,
                            audio_url = audioUrl,
                            exercise_id = requestDto.audioToUpdateDto.exercise_id,
                            part1 = requestDto.audioToUpdateDto.part1,
                            part2 = requestDto.audioToUpdateDto.part2,
                            part3 = requestDto.audioToUpdateDto.part3,
                            part4 = requestDto.audioToUpdateDto.part4,
                        };
                        await _audioRepository.UpdateAudioAsync(audioInForFile);
                    }                  
                    await _audioRepository.UpdateAudioAsync(requestDto.audioToUpdateDto);
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

        public async Task<List<ExerciseInfo>> GetExercises()
        {
            return await _exerciseRepository.GetExercisesAsync();
        }
        public  async Task<List<ExerciseInfo>> GetExercisesByCategoryDetail(string categoryDetailId)
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
