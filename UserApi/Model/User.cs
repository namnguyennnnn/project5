using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserApi.Model
{
    public class User
    {
        [Key]
        [MaxLength(36)]
        public string uid { get; set; }
        [MaxLength(50)]
        public string user_name { get; set; }
        [MaxLength(30)]
        public string password { get; set; }     
        public string account { get; set; }
        public string avatar { get; set; }
        public bool is_verified { get; set; }       
    }
}
