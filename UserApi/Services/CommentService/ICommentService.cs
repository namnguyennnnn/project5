using UserApi.DTO;
using UserApi.DTO.ForGetCommentByExercise;

namespace UserApi.Services.CommentService
{
    public interface ICommentService
    {
        Task<CreateCommentDto> AddComment(CreateCommentDto createCommentDto);
        Task<GetCommentsOfUserDto> GetCommentsByIdUser(string uid);
        Task<CommentInfoDto> GetCommentsByIdLecture(string lectureId);
        Task<List<UserCommentDto>> GetCommentsByParentCommentId(string parentCommentId);
       
        Task<CommentInfoDto> GetCommentsByIdExercise(string exerciseId, int page , int commentPerPage);
        Task<CreateCommentDto> UpdateComment(string commentId, UpdateCommentDto updateCommentDto);
        Task<ResultResponse> DeleteComment(string commentId);
    }
}
