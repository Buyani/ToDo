

using ToDo.Application.Dto;

namespace ToDo.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<GetUserResponse> CreateUserOrUpdate(CreateUserRequest createUserRequest);
        GetUserResponse GetUserByEmail(string email);
    }
}
