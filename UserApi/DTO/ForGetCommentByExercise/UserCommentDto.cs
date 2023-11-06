namespace UserApi.DTO.ForGetCommentByExercise
{
    public class UserCommentDto
    {
        public InfoUserDto? userSend { get; set; }
        public InfoUserDto? userRecive { get; set; }
        public CreateCommentDto? comment { get; set; }
    }
}
