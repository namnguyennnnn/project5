using System.ComponentModel.DataAnnotations;

namespace UsersApi.DTO
{
    public class UpdateUserDto
    {

        public string? UserName { get; set; } = null;
        
        public string? Password { get; set; } = null;

        public string? Account { get; set; } = null;

        public string? Avatar { get; set; } = null;

        public IFormFile? avatarFile { get; set; } = null;
    }
}
