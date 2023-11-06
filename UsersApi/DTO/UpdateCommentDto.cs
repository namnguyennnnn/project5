namespace UsersApi.DTO
{
    public class UpdateCommentDto
    {
        
        public string? content { get; set; }

        public string? parent_comment_id { get; set; }

        public string? create_at { get; set; }

        public int? total_replies { get; set; }

        public string? uid_sending { get; set; }

        public string? uid_receiving { get; set; }

        public string? exercise_id { get; set; }

        public string? lecture_id { get; set; }
    }
}
