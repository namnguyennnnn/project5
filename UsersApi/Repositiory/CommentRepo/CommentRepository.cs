using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.DTO;
using UsersApi.DTO.ForGetCommentByExercise;
using UsersApi.Model;

namespace UsersApi.Repositiory.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CommentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> GetTotalCommentsByExerciseIdAsync(string exerciseId)
        {
            return await _context.comments
                .Where(comment => comment.exercise_id == exerciseId)
                .CountAsync();
        }

   
    }
}
