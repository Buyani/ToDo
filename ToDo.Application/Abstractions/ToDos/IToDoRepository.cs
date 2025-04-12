

using ToDo.Application.Abstractions.Data;
using ToDo.Domain.Entities.ToDos;

namespace ToDo.Application.Abstractions.ToDos
{
    public interface IToDoRepository :IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetUserToDos(Guid id);
        bool ToDoExist(string description, Guid userId);
    }
}
