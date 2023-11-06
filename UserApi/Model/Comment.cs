using System.ComponentModel.DataAnnotations;

namespace UserApi.Model
{
    public class Comment
    {
        [Key, MaxLength(36)]
        public string comment_id { get; set; }
        public string content { get; set; }
        public string? parent_comment_id { get; set; } = string.Empty;
        public string create_at { get; set; }
        public int total_replies { get; set; }
        [MaxLength(36)]
        public string uid_sending { get; set; }        
        [MaxLength(36)]
        public string? lecture_id { get; set; }
        [MaxLength(36)]
        public string? uid_receiving { get; set; } = string.Empty;
        [MaxLength(36)]
        public string? exercise_id { get; set; }

        public User? SendingUser { get; set; }

        public User? ReceivingUser { get; set; } = null;
    }
}
