
using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;


namespace ExercisesApi.Repository.ExerciseRepo
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ExerciseRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ExerciseInfo>> GetExercisesByCategoryDetailIdAsync(string categoryDetailId)
        {
            var exercises = await _context.exercises
                .Where(e => e.category_detail_id == categoryDetailId)
                .ToListAsync();

            var exerciseInfoList = _mapper.Map<List<ExerciseInfo>>(exercises);

            return exerciseInfoList;
        }

       
        public async Task<Exercise> GetExamByIdExerciseAsync(string exerciseId)
        {
            var exercise = await _context.exercises
                .Include(e => e.questions)
                    .ThenInclude(q => q.answer)
                .Include(e => e.questions)
                    .ThenInclude(q => q.paragraph)
                .FirstOrDefaultAsync(e => e.exercise_id == exerciseId);


            foreach (var question in exercise.questions)
            {
                _context.Entry(question)
                    .Reference(q => q.image)
                    .Load();
            }

            return exercise;
        }

        public async Task<GetExerciseToUpdateDto> GetExerciseByIdForUpdateAsync(string exerciseId)
        {
            var exercise = await _context.exercises
                .Include(e => e.questions)
                    .ThenInclude(q => q.answer)
                .Include(e => e.questions)
                    .ThenInclude(q => q.paragraph)
                .Include(e => e.questions)
                    .ThenInclude(q => q.image)
                .Include(e => e.audio)
                .FirstOrDefaultAsync(e => e.exercise_id == exerciseId);
            exercise.questions = exercise.questions.OrderBy(q => q.index).ToList();
            foreach (var question in exercise.questions)
            {
                _context.Entry(question)
                    .Reference(q => q.image)
                    .Load();
            }

            var updateExerciseRequest = new GetExerciseToUpdateDto
            {
                category_detail_id = exercise.category_detail_id,
                title_of_exercise = exercise.title_of_exercise,
                exercise_description = exercise.exercise_description,
                audioDto = new GetAudioToUpdateDto
                {
                    audio_id = exercise.audio.audio_id,
                    audio_url = exercise.audio.audio_url,
                    part1 = exercise.audio.part1,
                    part2 = exercise.audio.part2,
                    part3 = exercise.audio.part3,
                    part4 = exercise.audio.part4
                },
                questionDtos = new List<GetQuestionToUpdateDto>()
            };

            foreach (var question in exercise.questions)
            {
                var updateQuestionDto = new GetQuestionToUpdateDto
                {
                    question_id = question.question_id,
                    question_content = question.question_content,
                    index = question.index,
                    answer = new GetAnswerToUpdateDto
                    {
                        question_id = question.question_id,
                        answer_explanation = question.answer.answer_explanation,
                        a = question.answer.a,
                        b = question.answer.b,
                        c = question.answer.c,
                        d = question.answer.d,
                        corect_answer = question.answer.corect_answer
                    }
                };


                if (question.image != null)
                {
                    updateQuestionDto.imageDto = new GetImageToUpdateDto
                    {
                        image_id = question.image.image_id,
                        question_id = question.question_id,
                        image_url = question.image.image_url
                    };
                }


                if (question.paragraph != null)
                {
                    updateQuestionDto.paragraphDto = new GetParagraphToUpdateDto
                    {
                        paragrahp_Id = question.paragraph.paragraph_id,
                        question_id = question.question_id,
                        paragrahp_url = question.paragraph.paragraph_url
                    };
                }

                updateExerciseRequest.questionDtos.Add(updateQuestionDto);
            }

            return updateExerciseRequest;
        }

        public async Task<(List<Question>, List<Answer>)> GetQuestionsAndAnswersByExerciseIdAsync(string exerciseId)
        {
            var questions = await _context.questions
            .Where(q => q.exercise_id == exerciseId)
            .ToListAsync();
            var questionIds = questions.Select(q => q.question_id).ToList();
            var answers = await _context.answers
            .Where(a => questionIds.Contains(a.question_id))
            .ToListAsync();
            return (questions, answers);
        }

        public async Task<List<ExerciseInfo>> GetExercisesAsync()
        {
            List<Exercise> exercises = await _context.exercises.ToListAsync();
            var exerciseInfoList = _mapper.Map<List<ExerciseInfo>>(exercises);
            return exerciseInfoList;
        }
        public async Task AddExerciseAsync(Exercise exercise)
        {
            _context.exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(ExerciseInfo updateExerciseDto)
        {
            var exittingExercise = await _context.exercises.FirstOrDefaultAsync(e => e.exercise_id == updateExerciseDto.exercise_id);
            if(exittingExercise != null)
            {
                exittingExercise.title_of_exercise = updateExerciseDto.title_of_exercise;
                exittingExercise.category_detail_id = updateExerciseDto.category_detail_id;
                exittingExercise.exercise_description = updateExerciseDto.exercise_description;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExerciseAsync(string exerciseId)
        {
            var exercisesToDelete = await _context.exercises
                 .Include(e => e.questions)
                     .ThenInclude(q => q.image)
                 .Include(e => e.audio)
                 .Where(e => e.exercise_id == exerciseId)
                 .ToListAsync();
            foreach (var exercise in exercisesToDelete)
            {
                // Xóa audio liên quan đến bài tập
                if (exercise.audio != null)
                {
                    _context.audio.Remove(exercise.audio);
                }

                // Xóa các câu hỏi và hình ảnh liên quan đến bài tập
                foreach (var question in exercise.questions)
                {
                    if (question.image != null)
                    {
                        _context.images.Remove(question.image);
                    }
                    if (question.answer != null)
                    {
                        _context.answers.Remove(question.answer);
                    }
                }

                _context.exercises.Remove(exercise);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExercisesByCategoryDetailIdAsync(string categoryDetailId)
        {         
            var exercisesToDelete = await _context.exercises
                .Include(e => e.questions)
                    .ThenInclude(q => q.image)
                .Include(e => e.audio)
                .Where(e => e.category_detail_id == categoryDetailId)
                .ToListAsync();

            foreach (var exercise in exercisesToDelete)
            {
               
                if (exercise.audio != null)
                {
                    _context.audio.Remove(exercise.audio);
                }

                
                foreach (var question in exercise.questions)
                {
                    if (question.image != null)
                    {
                        _context.images.Remove(question.image);
                    }
                    if (question.answer != null)
                    {
                        _context.answers.Remove(question.answer);
                    }
                }
               
                _context.exercises.Remove(exercise);
            }

            await _context.SaveChangesAsync();
        }


       

    }
}
