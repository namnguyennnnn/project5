using System.ComponentModel.DataAnnotations;

namespace UsersApi.Model
{
    public class User
    {
        [Key]
        [MaxLength(36)]
        public string uid { get; set; }
        [MaxLength(50)]
        public string user_name { get; set; }      
        public string password { get; set; }     
        public string account { get; set; }
        public string avatar { get; set; }
        public bool is_verified { get; set; }
        [MaxLength(1)]
        public int role { get; set; }
        public List<Comment>? SentComments { get; set; }

        public List<Comment>? ReceivedComments { get; set; }
    }
}
