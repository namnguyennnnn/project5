namespace UserApi.DTO
{
    public class GetUserDto
    {
        public string? uid { get; set; }

        public string? username { get; set; }

        public string? password { get; set; }

        public string? account { get; set; }

        public string? avatar { get; set; }

        public bool isVerified { get; set; }

        public int? role { get; set; }
    }
}
