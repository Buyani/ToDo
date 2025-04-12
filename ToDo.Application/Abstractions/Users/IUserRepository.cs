
using ToDo.Application.Abstractions.Data;
using ToDo.Domain.Entities.Users;

namespace ToDo.Application.Abstractions.Users
{
    public interface IUserRepository :IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
