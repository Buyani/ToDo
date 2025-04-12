
using ToDo.Application.Abstractions.Users;
using ToDo.Application.Dto;
using ToDo.Application.Services.Users.Interfaces;
using ToDo.Domain.Entities.Users;
using ToDo.Shared;

namespace ToDo.Application.Services.Users.Implementations
{
    public class UserService(IUserRepository userRepository, IDateTimeProvider dateTimeProvider) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDateTimeProvider _dateTimeProvider= dateTimeProvider;

        public async Task<GetUserResponse> CreateUser(CreateUserRequest createUserRequest)
        {


            var user= await _userRepository.CreateAsync(new User
            {
                FirstName= createUserRequest.FirstName,
                LastName= createUserRequest.LastName,
                Email= createUserRequest.Email,
                CreatedAt = _dateTimeProvider.UtcNow,
                LastLogIn = _dateTimeProvider.UtcNow,
                Id = Guid.NewGuid()
            });

            return new GetUserResponse(user); ;
        }

        public GetUserResponse GetUserByEmail(string email)
        {
            var user= _userRepository.GetUserByEmail(email);

            if(user==null)
                return default!;

            return new GetUserResponse(user);
        }
    }
}
