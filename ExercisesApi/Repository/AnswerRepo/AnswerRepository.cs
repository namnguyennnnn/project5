using ExercisesApi.Data;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.AnswerRepo
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext _context;

        public AnswerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetAnswersByQuestionIdAsync(string questionId)
        {
            return await _context.answers.FindAsync(questionId);
                
        }

        public async Task<Answer> GetAnswerByIdAsync(string answerId)
        {
            return await _context.answers
                .FirstOrDefaultAsync(a => a.answer_id == answerId);
        }

        public async Task AddAnswersAsync(List<Answer> answers)
        {
            _context.answers.AddRange(answers);
            await _context.SaveChangesAsync();
        }
        public async Task AddAnswerAsync(Answer answer)
        {
            _context.answers.Add(answer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAnswerAsync(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnswerAsync(string answerId)
        {
            var answer = await _context.answers.FindAsync(answerId);
            if (answer != null)
            {
                _context.answers.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
