
using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO;
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

        public async Task<Exercise> GetExerciseByIdAsync(string exerciseId)
        {
            return await _context.exercises
                .FirstOrDefaultAsync(e => e.exercise_id == exerciseId);
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            _context.exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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
            // Lấy tất cả các bài tập có category_detail_id cụ thể
            var exercisesToDelete = await _context.exercises
                .Include(e => e.questions)
                    .ThenInclude(q => q.image)
                .Include(e => e.audio)
                .Where(e => e.category_detail_id == categoryDetailId)
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


        public async Task<Exercise> GetExamByIdExerciseAsync(string exerciseId)
        {
            var exercise = await _context.exercises
                .Include(e => e.questions) 
                    .ThenInclude(q => q.answer) 
                .FirstOrDefaultAsync(e => e.exercise_id == exerciseId);

          
            foreach (var question in exercise.questions)
            {
                _context.Entry(question)
                    .Reference(q => q.image)
                    .Load();
            }

            return exercise;
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
    }
}
