using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.DTO;
using UserApi.DTO.ForGetCommentByExercise;
using UserApi.Model;

namespace UserApi.Repositiory.CommentRepo
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

        public async Task AddCommentAsync(CreateCommentDto createCommentDto)
        {
            var newComment = _mapper.Map<Comment>(createCommentDto);
            _context.comments.Add(newComment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCommentAsync(string commentId)
        {
            var exitComment = await _context.comments.FindAsync(commentId);
            if (exitComment != null)
            {
                _context.comments.Remove(exitComment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CreateCommentDto> GetCommentByIdAsync(string commentId)
        {
            var comment = await _context.comments.FindAsync(commentId);
            return _mapper.Map<CreateCommentDto>(comment);
        }

        public async Task<List<UserCommentDto>> GetcommentsByIdExerciseAsync(string exerciseId, int page, int commentsPerPage)
        {
            var skip = (page - 1) * commentsPerPage;
            var comments = await _context.comments
                .Where(c => c.exercise_id == exerciseId)
                .Include(c => c.SendingUser)
                .Include(c => c.ReceivingUser)
                .Where(c => c.parent_comment_id == null)
                .OrderByDescending(c => c.create_at)
                .Skip(skip)
                .Take(commentsPerPage)
                .ToListAsync();

            var userComments = comments.Select(comment => new UserCommentDto
            {
                userSend = new InfoUserDto
                {
                    uid = comment.SendingUser.uid,
                    user_name = comment.SendingUser.user_name,
                    account = comment.SendingUser.account,
                    avatar = comment.SendingUser.avatar
                },
                userRecive = new InfoUserDto
                {
                    uid = comment.ReceivingUser?.uid,
                    user_name = comment.ReceivingUser?.user_name,
                    account = comment.ReceivingUser?.account,
                    avatar = comment.ReceivingUser?.avatar
                },
                comment = new CreateCommentDto
                {
                    comment_id = comment.comment_id,
                    content = comment.content,
                    parent_comment_id = comment.parent_comment_id,
                    create_at = comment.create_at,
                    total_replies = comment.total_replies,
                    uid_sending = comment.uid_sending,
                    uid_receiving = comment.uid_receiving,
                    exercise_id = comment.exercise_id
                }
            }).ToList();

            return userComments;
        }

      
        public async Task<List<UserCommentDto>> GetcommentsByIdLectureAsync(string lectureId)
        {
            var comments = await _context.comments
                .Where(c => c.lecture_id == lectureId)
                .Include(c => c.SendingUser)
                .Include(c => c.ReceivingUser)
                .Where(c => c.parent_comment_id == null)
                .OrderByDescending(c => c.create_at)              
                .ToListAsync();

            var userComments = comments.Select(comment => new UserCommentDto
            {
                userSend = new InfoUserDto
                {
                    uid = comment.SendingUser.uid,
                    user_name = comment.SendingUser.user_name,
                    account = comment.SendingUser.account,
                    avatar = comment.SendingUser.avatar
                },
                userRecive = new InfoUserDto
                {
                    uid = comment.ReceivingUser?.uid,
                    user_name = comment.ReceivingUser?.user_name,
                    account = comment.ReceivingUser?.account,
                    avatar = comment.ReceivingUser?.avatar
                },
                comment = new CreateCommentDto
                {
                    comment_id = comment.comment_id,
                    content = comment.content,
                    parent_comment_id = comment.parent_comment_id,
                    create_at = comment.create_at,
                    total_replies = comment.total_replies,
                    uid_sending = comment.uid_sending,
                    uid_receiving = comment.uid_receiving,
                    lecture_id = comment.lecture_id
                }
            }).ToList();

            return userComments;
        }

        public async Task<List<UserCommentDto>> GetcommentsByIdParentCommentAsync(string parentCommentId)
        {
            var comments = await _context.comments
                .Where(c => c.parent_comment_id == parentCommentId)
                .Include(c => c.SendingUser)
                .Include(c => c.ReceivingUser)
                .ToListAsync();

            var userComments = comments.Select(comment => new UserCommentDto
            {
                userSend = new InfoUserDto
                {
                    uid = comment.SendingUser.uid,
                    user_name = comment.SendingUser.user_name,
                    account = comment.SendingUser.account,
                    avatar = comment.SendingUser.avatar
                },
                userRecive = new InfoUserDto
                {
                    uid = comment.ReceivingUser?.uid,
                    user_name = comment.ReceivingUser?.user_name,
                    account = comment.ReceivingUser?.account,
                    avatar = comment.ReceivingUser?.avatar
                },
                comment = new CreateCommentDto
                {
                    comment_id = comment.comment_id,
                    content = comment.content,
                    parent_comment_id = comment.parent_comment_id,
                    create_at = comment.create_at,
                    total_replies = comment.total_replies,
                    uid_sending = comment.uid_sending,
                    uid_receiving = comment.uid_receiving,
                    exercise_id = comment.exercise_id
                }
            }).ToList();

            return userComments;

        }

        public async Task<int> GetTotalCommentsByExerciseIdAsync(string exerciseId)
        {
            return await _context.comments
                .Where(comment => comment.exercise_id == exerciseId)
                .CountAsync();
        }
        public async Task<int> GetTotalCommentsByLectureIdAsync(string lectureId)
        {
            return await _context.comments
                .Where(comment => comment.lecture_id == lectureId)
                .CountAsync();
        }
        public async Task UpdateCommentAsync(string commentId, UpdateCommentDto updateCommentDto)
        {
            var exitComment = await _context.comments.FindAsync(commentId);
            if (exitComment != null)
            {
                exitComment.content = updateCommentDto.content?? exitComment.content;
                exitComment.uid_sending = updateCommentDto.uid_sending ?? exitComment.uid_sending;
                exitComment.uid_receiving = updateCommentDto.uid_receiving ?? exitComment.uid_receiving;
                exitComment.exercise_id = updateCommentDto.exercise_id ?? exitComment.exercise_id;
                exitComment.parent_comment_id = updateCommentDto.parent_comment_id ?? exitComment.parent_comment_id;              
                exitComment.create_at = updateCommentDto.create_at ?? exitComment.create_at;              
                exitComment.total_replies = updateCommentDto.total_replies ?? exitComment.total_replies;                   
                exitComment.lecture_id = updateCommentDto?.lecture_id ?? exitComment.lecture_id;
                _context.comments.Update(exitComment);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
