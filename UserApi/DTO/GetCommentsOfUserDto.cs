namespace UserApi.DTO
{
    public class GetCommentsOfUserDto
    {
        public string? uid { get; set; }

        public string? user_name { get; set; }

        public string? account { get; set; }

        public string? avatar { get; set; }

        public List<CreateCommentDto>? comments { get; set; }
    }
}
