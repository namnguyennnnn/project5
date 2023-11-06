using UsersApi.DTO;
using UsersApi.DTO.ForGetCommentByExercise;

namespace UsersApi.Repositiory.CommentRepo
{
    public interface ICommentRepository
    {
        Task<int> GetTotalCommentsByExerciseIdAsync(string exerciseId);

    }
}
