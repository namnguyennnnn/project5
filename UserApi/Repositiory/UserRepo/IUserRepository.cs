
using UserApi.DTO;

namespace UserApi.Repositiory.UserRepo
{
    public interface IUserRepository
    {
        Task AddUserAsync(GetUserDto createUserDto);
        Task<GetUserDto> GetUserByIdAsync(string uid);
        Task<List<GetUserDto>> GetUsersAsync();
        Task<GetCommentsOfUserDto> GetCommentsOfUserAync(string uid);
        Task UpdateUserAsync(string uid, UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(string uid);
        Task<GetUserDto> GetUserByEmailAsync(string email);
        Task VerifyAccount(string account);
        Task<List<GetUserDto>> GetUsersByIdsAsync(List<string> uids);
        Task UpdatePassword(string account, string password);
    }
}
