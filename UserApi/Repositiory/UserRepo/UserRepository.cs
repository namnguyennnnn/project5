using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.DTO;
using UserApi.Model;

namespace UserApi.Repositiory.UserRepo
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
             var user = await _context.users.FirstOrDefaultAsync(u=> u.account==email);
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> GetUserByIdAsync(string uid)
        {
            var existUser = await _context.users.FindAsync(uid);
            if (existUser != null)
            {
                return _mapper.Map<GetUserDto>(existUser);
            }
            return null;
        }

        public async Task<List<GetUserDto>> GetUsersAsync()
        {
            var users = await _context.users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task AddUserAsync(GetUserDto createUserDto) 
        {
            var newUser = _mapper.Map<User>(createUserDto);
            await _context.users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(string uid)
        {
            var user = await _context.users.FindAsync(uid);
            if (user == null)
            {
                return false; 
            }
         
            var userComments = _context.comments
                .Where(comment => comment.uid_sending == uid || comment.uid_receiving == uid)
                .ToList();
            if(userComments.Count > 0)
            {
                _context.comments.RemoveRange(userComments);
            }
            
            _context.users.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }



        public async Task UpdateUserAsync(string uid, UpdateUserDto updateUserDto)
        {
            var existingUser = await _context.users.FindAsync(uid);
            if (existingUser == null)
                return;

            existingUser.user_name = updateUserDto.username ?? existingUser.user_name;
            existingUser.account = updateUserDto.account ?? existingUser.account;
            existingUser.password = updateUserDto.password ?? existingUser.password;
            existingUser.avatar = updateUserDto.avatar ?? existingUser.avatar;

            await _context.SaveChangesAsync();

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

        public async Task<GetCommentsOfUserDto> GetCommentsOfUserAync(string uid)
        {
            var user = await _context.users
                .Where(u => u.uid == uid)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var comments = await _context.comments
                    .Where(c => c.uid_sending == uid )
                    .ToListAsync();

                var userDto = new GetCommentsOfUserDto
                {
                    uid = user.uid,
                    user_name = user.user_name,
                    account = user.account,
                    avatar = user.avatar,
                    comments = comments.Select(comment => new CreateCommentDto
                    {
                        comment_id = comment.comment_id,
                        content = comment.content,
                        parent_comment_id = comment.parent_comment_id,
                        create_at = comment.create_at,
                        total_replies = comment.total_replies,
                        uid_sending = comment.uid_sending,
                        uid_receiving = comment.uid_receiving,
                        exercise_id = comment.exercise_id
                    }).ToList()
                };

                return userDto;
            }
            else
            {
                return null;
            }

        }
        public async Task<List<GetUserDto>> GetUsersByIdsAsync(List<string> uids)
        {
            var users = await _context.users.Where(u => uids.Contains(u.uid)).ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }
        public async Task UpdatePassword(string account, string password)
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
