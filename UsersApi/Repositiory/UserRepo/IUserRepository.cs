
using UsersApi.DTO;

namespace UsersApi.Repositiory.UserRepo
{
    public interface IUserRepository
    {
        Task AddUserAsync(GetUserDto createUserDto);
        Task<List<GetUserDto>> GetUsersByIdsAsync(List<string> uids);
        Task<GetUserDto> GetUserByEmailAsync(string email);
        Task VerifyAccount(string account);
        Task UpdatePassword(string account, string password);
    }
}
