using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.QuestionRepo
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public QuestionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Question>> GetQuestionsByExerciseIdAsync(string exerciseId)
        {
            return await _context.questions
                .Where(q => q.exercise_id == exerciseId)
                .OrderBy(q => q.index) 
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(string questionId)
        {
            return await _context.questions
                .FirstOrDefaultAsync(q => q.question_id == questionId);
        }

        public async Task AddQuestionsAsync(List<Question> questions)
        {
            _context.questions.AddRange(questions);
            await _context.SaveChangesAsync();
        }
        public async Task AddQuestionAsync(Question question)
        {
            _context.questions.Add(question);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateQuestionAsync(List<UpdateQuestionDto> updateQuestionDtos)
        {
            foreach (var updatedQuestion in updateQuestionDtos)
            {
                var existingQuestion = await _context.questions.FirstOrDefaultAsync(q => q.question_id == updatedQuestion.question_id);

                if (existingQuestion != null)
                {
                    existingQuestion.question_content = updatedQuestion.question_content;
                    existingQuestion.exercise_id = updatedQuestion.exercise_id;
                    existingQuestion.index = updatedQuestion.index;

                    _context.questions.Update(existingQuestion);
                   
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuestionAsync(string questionId)
        {
            var question = await _context.questions.FindAsync(questionId);
            if (question != null)
            {
                _context.questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteQuestionByIdExerciseAsync(string exerciseId)
        {
            var questionsToDelete = await _context.questions
            .Where(q => q.exercise_id == exerciseId)
            .ToListAsync();

            foreach (var question in questionsToDelete)
            {
                _context.questions.Remove(question);
            }

            await _context.SaveChangesAsync();
        }
      
    }
}
