
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions.ToDos;
using ToDo.Domain.Entities.ToDos;
using ToDo.Infrastructure.DataBase;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoRepository(ApplicationDbContext context) :
        Repository<TodoItem>(context), IToDoRepository
    {
        public async Task<IEnumerable<TodoItem>> GetUserToDos(Guid userId)
        {
            return await GetAllAsync()
            .Where(todo => todo.UserId == userId)
            .ToListAsync();
        }

        public bool ToDoExist(string description,Guid userId)
        {
            var todo=  GetAllAsync().FirstOrDefault(item=> item.Description!.ToLower().Trim() == description.ToLower().Trim() &&
            item.UserId == userId); 
            return todo != null;
        }
    }
}
