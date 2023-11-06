using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.ParagraphRepo
{
    public class ParagraphRepository : IParagraphRepository
    {
        private readonly DataContext _context;
        public ParagraphRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task AddParagraphAsync(Paragraph paragraph)
        {
            _context.paragraphs.Add(paragraph);
            await _context.SaveChangesAsync();
        }

        public async Task<Paragraph> GetParagraphByQuestionIdAsync(string questionId)
        {
            return await _context.paragraphs.FirstOrDefaultAsync(p => p.question_id == questionId);
        }
     

        public async Task DeleteParagraphAsync(string questionId)
        {
            var paragraphToDelete = _context.paragraphs.FirstOrDefault(i => i.question_id == questionId);
            if (paragraphToDelete != null)
            {
                _context.paragraphs.Remove(paragraphToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddParagraphsAsync(List<Paragraph> paragraphs)
        {
            _context.paragraphs.AddRange(paragraphs);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParagraphsAsync(List<CreateParagraphDto> updateParagraphDtos)
        {
            foreach (var updateParagraph in updateParagraphDtos)
            {
                var existingParagraph = await _context.paragraphs.FirstOrDefaultAsync(p => p.paragraph_id == updateParagraph.paragraph_id);

                if (existingParagraph != null)
                {
                    existingParagraph.paragraph_url = updateParagraph.paragraph_url ?? existingParagraph.paragraph_url;
                    existingParagraph.question_id = updateParagraph.question_id?? existingParagraph.question_id;
                    _context.paragraphs.Update(existingParagraph);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
