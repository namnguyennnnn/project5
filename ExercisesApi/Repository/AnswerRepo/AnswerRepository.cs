using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.DTO.GetInfoExerciseToUpdateDto;
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.AnswerRepo
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AnswerRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
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
        public async Task UpdateAnswerAsync(List<GetAnswerToUpdateDto> updateAnswerDtos)
        {
            foreach (var updateAnswer in updateAnswerDtos)
            {
                var existingAnswer = await _context.answers.FirstOrDefaultAsync(a => a.answer_id == updateAnswer.answer_id);

                if (existingAnswer != null)
                {
                    existingAnswer.answer_explanation = updateAnswer.answer_explanation;
                    existingAnswer.a = updateAnswer.a;
                    existingAnswer.b = updateAnswer.a;
                    existingAnswer.c = updateAnswer.a;
                    existingAnswer.d = updateAnswer.a;
                    existingAnswer.corect_answer = updateAnswer.corect_answer;

                    _context.answers.Update(existingAnswer);
                    
                }
            }
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
