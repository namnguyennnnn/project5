
namespace UserApi.DTO
{
    public class UpdateUserDto
    {

        public string? username { get; set; } = null;

        public string? password { get; set; } = null;

        public string? account { get; set; } = null;

        public string? avatar { get; set; } = null;

        public IFormFile? avatarFile { get; set; } = null;
    }
}
