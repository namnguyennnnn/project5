namespace UsersApi.DTO
{
    public class GetUserDto
    {
        public string? uid { get; set; }

        public string? user_name { get; set; }

        public string? password { get; set; }

        public string? account { get; set; }

        public string? avatar { get; set; }

        public bool is_verified { get; set; }

        public int? role { get; set; }
    }
}
