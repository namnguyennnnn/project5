using System.ComponentModel.DataAnnotations;

namespace UserApi.DTO
{
    public class CreateCommentDto
    {
        public string? comment_id { get; set; }

        public string? content { get; set; }

        public string? parent_comment_id { get; set; } = string.Empty;

        public string? create_at { get; set; }

        public int total_replies { get; set; }

        public string? uid_sending { get; set; } = string.Empty;

        public string? uid_receiving { get; set; }

        public string? exercise_id { get; set; }

        public string? lecture_id { get; set; }
    }
}
