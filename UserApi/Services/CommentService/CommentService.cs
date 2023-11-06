using UserApi.DTO;
using UserApi.Repositiory.CommentRepo;
using UserApi.Repositiory.UserRepo;
using UserApi.DTO.ForGetCommentByExercise;

namespace UserApi.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
       
        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
           
        }

        public async Task<CreateCommentDto> AddComment(CreateCommentDto createCommentDto)
        {
            if (createCommentDto == null)
            {
                throw new ArgumentNullException(nameof(createCommentDto), "createCommentDto cannot be null");
            }

            try
            {
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                var newComment = new CreateCommentDto
                {
                    comment_id = Guid.NewGuid().ToString(),
                    content = createCommentDto.content,
                    exercise_id = string.IsNullOrEmpty(createCommentDto.exercise_id) ? null : createCommentDto.exercise_id,
                    parent_comment_id = string.IsNullOrEmpty(createCommentDto.parent_comment_id) ? null : createCommentDto.parent_comment_id,
                    uid_sending = createCommentDto.uid_sending,
                    uid_receiving = string.IsNullOrEmpty(createCommentDto.uid_receiving) ? null : createCommentDto.uid_receiving,
                    create_at = localTime.ToString(),
                    total_replies = 0,
                    lecture_id = string.IsNullOrEmpty(createCommentDto.lecture_id) ? null: createCommentDto.lecture_id
                };

                await _commentRepository.AddCommentAsync(newComment);

                if (createCommentDto.parent_comment_id != null)
                {
                    var parentComment = await _commentRepository.GetCommentByIdAsync(createCommentDto.parent_comment_id);
                    if (parentComment != null)
                    {
                        var updateParentComment = new UpdateCommentDto { total_replies = parentComment.total_replies + 1 };
                        await _commentRepository.UpdateCommentAsync(createCommentDto.parent_comment_id, updateParentComment);
                    }
                }

                return newComment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ResultResponse> DeleteComment(string commentId)
        {
            if (commentId != null) 
            {
                if(await _commentRepository.DeleteCommentAsync(commentId) == true)
                {
                    return new ResultResponse { StatusCode = 200, StatusDetail = "Success" };
                }
                return new ResultResponse { StatusCode = 400, StatusDetail = "Comment doesn't exits" };
            }
            return new ResultResponse { StatusCode = 404, StatusDetail = "Commnent Not Found" };
        }


        public async Task<CommentInfoDto> GetCommentsByIdExercise(string exerciseId, int page , int commentPerPage)
        {
            var CommentsInfo = new List<UserCommentDto>();
            try
            {
                var comments = await _commentRepository.GetcommentsByIdExerciseAsync(exerciseId ,page,commentPerPage);

                if (comments == null)
                {
                    return null;
                }
            
                return new CommentInfoDto
                {
                  total_replies = await _commentRepository.GetTotalCommentsByExerciseIdAsync(exerciseId),
                  Comments = comments
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CommentInfoDto> GetCommentsByIdLecture(string lectureId)
        {
            var CommentsInfo = new List<UserCommentDto>();
            try
            {
                var comments = await _commentRepository.GetcommentsByIdLectureAsync(lectureId);

                if (comments == null)
                {
                    return null;
                }

                return new CommentInfoDto
                {
                    total_replies = await _commentRepository.GetTotalCommentsByLectureIdAsync(lectureId),
                    Comments = comments
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetCommentsOfUserDto> GetCommentsByIdUser(string uid)
        {
            if(uid == null)
            {
                throw new ArgumentNullException(nameof(uid), "Uid null");
            }
            return await _userRepository.GetCommentsOfUserAync(uid);        
        }

        public async Task<List<UserCommentDto>> GetCommentsByParentCommentId(string parentCommentId)
        {
            if (parentCommentId == null)
            {
                throw new ArgumentNullException(nameof(parentCommentId), "parentCommentId null");
            }
            return await _commentRepository.GetcommentsByIdParentCommentAsync(parentCommentId);
        }

        public async Task<CreateCommentDto> UpdateComment(string commentId, UpdateCommentDto updateCommentDto)
        {
            try
            {
                if (string.IsNullOrEmpty(commentId) || updateCommentDto == null)
                {                  
                    throw new ArgumentException("Invalid commentId or updateCommentDto");
                }              
                await _commentRepository.UpdateCommentAsync(commentId, updateCommentDto);
             
                return await _commentRepository.GetCommentByIdAsync(commentId);
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

    }
}
