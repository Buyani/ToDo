
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.ToDos;
using ToDo.Domain.Entities.Users;

namespace ToDo.Infrastructure.DataBase
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
        DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }

}
