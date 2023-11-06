using UserManagement;
using UserApi.Repositiory.UserRepo;
using Grpc.Core;
using UserApi.DTO;
using UserApi.Repositiory.CommentRepo;

namespace UserApi.Services
{
    public class UserGrpcFunction: UserManagement.UserManager.UserManagerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        
        public UserGrpcFunction(IUserRepository userRepository, ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
           
        }

        public override async Task<GetUserByEmailResponse> GetUserByEmail(GetUserByEmailRequest request, ServerCallContext context)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Account);   
            if (user == null)
            {
                return new GetUserByEmailResponse{ };
            }
            return await Task.FromResult(new GetUserByEmailResponse
            {
                Uid = user.uid,
                UserName = user.username,
                Account = user.account,
                Password = user.password,
                Avatar  =user.avatar,
                IsVerified= user.isVerified,
                Role = user.role ?? 0                           
            });
        }

        public override async Task<GetUsersByIdsResponse> GetUsersByIds(GetUsersByIdsRequest request, ServerCallContext context)
        {
            var uids = request.Uids.Select(uid => uid.Uid).ToList();
            var users = await _userRepository.GetUsersByIdsAsync(uids);
            if (users == null)
            {
                return new GetUsersByIdsResponse { };
            }
            var infoUsers = users.Select(user => new GetUserByEmailResponse
            {
                Uid = user.uid,
                UserName = user.username,
                Account = user.account,
                Password = user.password,
                Avatar = user.avatar,
                IsVerified = user.isVerified,
                Role = user.role ?? 0
            }).ToList();

            var response = new GetUsersByIdsResponse
            {
                InforUsers = { infoUsers }
            };

            return response;
        }

        public override async Task<AddUserResponse> AddUser(AddUserRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.UserName))
                {
                    return new AddUserResponse { StatusCode = "400", StausDetail = "Invalid input data" };
                }

                var uid = Guid.NewGuid().ToString();

       
                var newUser = new GetUserDto
                {
                    uid = uid,
                    account = request.Account,
                    password = request.Password,
                    username = request.UserName,
                    avatar = "https://res.cloudinary.com/decejsrcc/image/upload/v1697169806/images/2fda05f9-3986-4061-8a09-9f45b18badf1_avatar.jpg.jpg",
                    isVerified = false,
                    role = 0, 
                };

                await _userRepository.AddUserAsync(newUser);

                return new AddUserResponse { StatusCode = "200", StausDetail = "Success" };
            }
            catch (Exception ex)
            {
                return new AddUserResponse { StatusCode = "500", StausDetail = ex.Message  };
            }
        }

        public override async Task<VerifyAccountResponse> VerifyAccount(VerifyAccountRequest request, ServerCallContext context)
        {
            try
            {
                
                if (string.IsNullOrEmpty(request.Account))
                {
                    return new VerifyAccountResponse { StatusCode = "400", StausDetail = "Invalid input data" };
                }
              
                await _userRepository.VerifyAccount(request.Account);
              
                return new VerifyAccountResponse { StatusCode = "200", StausDetail = "Success" };
            }
            catch (Exception ex)
            {
               
                return new VerifyAccountResponse { StatusCode = "500", StausDetail = ex.Message  };
            }
        }

        public override async Task<GetTotalCommentsResponse> GetTotalComments(GetTotalCommentsRequest request, ServerCallContext context)
        {
            var response = new GetTotalCommentsResponse();

            foreach (var exercise in request.Exercises)
            {
                var totalComments = await _commentRepository.GetTotalCommentsByExerciseIdAsync(exercise.ExerciseId);
                var totalCommentMessage = new TotalComment
                {
                    ExerciseId = exercise.ExerciseId,
                    CategoryDetailId = exercise.CategoryDetailId,
                    TitleOfExercise = exercise.TitleOfExercise,
                    ExerciseDescription = exercise.ExerciseDescription,
                    CreateAt = exercise.CreateAt,
                    TotalReplies = totalComments
                };

                response.Exercises.Add(totalCommentMessage);
            }

            return response;
        }

        public override async Task<UpdatePasswordResponse> UpdatePassword(UpdatePasswordRequest request, ServerCallContext context)
        {
            try
            {              
                if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
                {
                    return new UpdatePasswordResponse { StatusCode = "400", StausDetail = "Invalid input data" };
                }
              
                await _userRepository.UpdatePassword(request.Account, request.Password);
          
                return new UpdatePasswordResponse { StatusCode = "200", StausDetail = "Success" };
            }
            catch (Exception ex)
            {           
                return new UpdatePasswordResponse { StatusCode = "500", StausDetail = ex.Message };
            }
        }

    }
}
