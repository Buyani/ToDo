

using System.Runtime.InteropServices;
using ToDo.Application.Abstractions.Users;
using ToDo.Domain.Entities.Users;
using ToDo.Infrastructure.DataBase;

namespace ToDo.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) :
        Repository<User>(context), IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            var usersCollection = GetAllAsync().ToList();

           return usersCollection?.FirstOrDefault(user => user.Email == email);
        }
    }
}
