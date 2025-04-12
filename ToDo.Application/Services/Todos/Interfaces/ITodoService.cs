
using ToDo.Application.Dto;

namespace ToDo.Application.Services.Todos.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoItemResponse> GetUserTodos(string email);
        Task<TodoItemResponse> CreateTodo(CreateTodoItemRequest request);
    }
}
