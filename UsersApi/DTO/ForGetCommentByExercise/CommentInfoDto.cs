using System.ComponentModel.DataAnnotations;

namespace UsersApi.DTO.ForGetCommentByExercise
{
    public class CommentInfoDto
    {   
        public int? total_replies { get; set; }       
        public List<UserCommentDto>? Comments { get; set; }
    }
}
