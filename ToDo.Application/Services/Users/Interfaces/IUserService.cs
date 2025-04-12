

using ToDo.Application.Dto;

namespace ToDo.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<GetUserResponse> CreateUser(CreateUserRequest createUserRequest);
        GetUserResponse GetUserByEmail(string email);
    }
}
