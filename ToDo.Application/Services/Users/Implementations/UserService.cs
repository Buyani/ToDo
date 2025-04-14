
using Microsoft.Extensions.Logging;
using ToDo.Application.Abstractions.Users;
using ToDo.Application.Dto;
using ToDo.Application.Services.Users.Interfaces;
using ToDo.Domain.Entities.Users;
using ToDo.Shared;

namespace ToDo.Application.Services.Users.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IDateTimeProvider dateTimeProvider, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }
        public async Task<GetUserResponse> CreateUserOrUpdate(CreateUserRequest createUserRequest)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(createUserRequest.Email!);

                if (user == null)
                {
                    //user was not found 
                    _logger.LogInformation("User was not found for Email: {email}", createUserRequest.Email);
                    //create a new user
                    user = await AddUser(createUserRequest);
                }
                else
                {
                    //if user found to be existing just update users last login
                    _logger.LogInformation("User found for email : {}", user.Email);
                    await UpdateLastLogin(user);
                }

                return new GetUserResponse(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An error occurred while creating or updating user with Email: {email}", 
                    createUserRequest.Email);
                throw;
            }
        }

        public GetUserResponse GetUserByEmail(string email)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(email);

                if (user == null)
                {
                    _logger.LogInformation("No user found for email: {email}", email);
                    return default!;
                }

                return new GetUserResponse(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An error occurred while retrieving user for Email: {email}", email);
                throw;
                throw;
            }
        }
        private async Task<User> AddUser(CreateUserRequest createUserRequest)
        {
            _logger.LogInformation("Creating a new user account. Email: {email}, FirstName: {firstName}, LastName: {lastName}",
                                    createUserRequest.Email, createUserRequest.FirstName, createUserRequest.LastName);

            return await _userRepository.CreateAsync(new User
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Email = createUserRequest.Email,
                CreatedAt = _dateTimeProvider.UtcNow,
                LastLogIn = _dateTimeProvider.UtcNow,
                Id = Guid.NewGuid()
            });
        }
        private async Task UpdateLastLogin(User user)
        {
            //if user found to be existing just update users last login
            _logger.LogInformation("User found updating lastLogin");
            user.LastLogIn = _dateTimeProvider.UtcNow;
            await _userRepository.UpdateAsync(user);
        }
    }
}
