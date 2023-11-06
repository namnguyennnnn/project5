using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.examResponse;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.QuestionRepo
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;     
        }

        public async Task<List<QuestionDto>> GetQuestionsByExerciseIdAsync(string exerciseId)
        {
            var questions = await _context.questions
                .Where(q => q.exercise_id == exerciseId)
                .Include(q => q.answer)
                .OrderBy(q => q.index) 
                .ToListAsync();

            var questionDtos = questions.Select(q => new QuestionDto
            {
                question_id = q.question_id,
                question_content = q.question_content,
                index = q.index,
                corect_answer = q.answer.corect_answer,
                paragraph_url = q.paragraph?.paragraph_url,
                answer_explanation = q.answer.answer_explanation,
                answer = new AnswerDto
                {                   
                    a = q.answer.a,
                    b = q.answer.b,
                    c = q.answer.c,
                    d = q.answer.d
                },
                image_url = q.image?.image_url 
            }).ToList();

            return questionDtos;
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
        public async Task UpdateQuestionAsync(List<CreateQuestionDto> updateQuestionDtos)
        {
            foreach (var updatedQuestion in updateQuestionDtos)
            {
                var existingQuestion = await _context.questions.FirstOrDefaultAsync(q => q.question_id == updatedQuestion.question_id);

                if (existingQuestion != null)
                {
                    existingQuestion.question_content = updatedQuestion.question_content?? existingQuestion.question_content;
                    existingQuestion.exercise_id = updatedQuestion.exercise_id ?? existingQuestion.exercise_id;
                    existingQuestion.index = updatedQuestion.index?? existingQuestion.index;

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
