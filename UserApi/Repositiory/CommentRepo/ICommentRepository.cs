using UserApi.DTO;
using UserApi.DTO.ForGetCommentByExercise;

namespace UserApi.Repositiory.CommentRepo
{
    public interface ICommentRepository
    {
        Task<CreateCommentDto> GetCommentByIdAsync(string commentId);
        Task<List<UserCommentDto>> GetcommentsByIdExerciseAsync(string exerciseId, int page, int commentsPerPage);
        Task<int> GetTotalCommentsByExerciseIdAsync(string exerciseId);
        Task<int> GetTotalCommentsByLectureIdAsync(string lectureId);
        Task<List<UserCommentDto>> GetcommentsByIdLectureAsync(string lectureId);
        Task<List<UserCommentDto>> GetcommentsByIdParentCommentAsync(string parentCommentId);
        Task AddCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(string commentId,UpdateCommentDto updateCommentDto);
        Task<bool> DeleteCommentAsync(string commentId );
    }
}
