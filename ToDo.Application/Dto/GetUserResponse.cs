

using ToDo.Domain.Entities.Users;

namespace ToDo.Application.Dto
{
    public class GetUserResponse(User user)
    {
        public string? Email { get; set; } = user.Email;
        public Guid UserId { get; set; } = user.Id;
    }
}
