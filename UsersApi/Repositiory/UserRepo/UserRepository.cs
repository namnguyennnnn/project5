using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.DTO;
using UsersApi.Model;

namespace UsersApi.Repositiory.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<GetUserDto> GetUserByEmailAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.account == email);
            return _mapper.Map<GetUserDto>(user);
        }

       


        public async Task AddUserAsync(GetUserDto createUserDto) 
        {
            var newUser = _mapper.Map<User>(createUserDto);
            await _context.users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }


        public async Task<List<GetUserDto>> GetUsersByIdsAsync(List<string> uids)
        {
            var users = await _context.users.Where(u => uids.Contains(u.uid)).ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }
      
        public async Task VerifyAccount(string account)
        {
            var existingUser =  await _context.users.FirstOrDefaultAsync(u => u.account == account);
            if (existingUser != null)
            {
                existingUser.is_verified = true;
                _context.users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePassword(string account,string password)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.account == account);
            if (existingUser != null)
            {
                existingUser.password = password;
                _context.users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

    }
}
