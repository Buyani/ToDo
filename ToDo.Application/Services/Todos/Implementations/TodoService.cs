
using ToDo.Application.Abstractions.ToDos;
using ToDo.Application.Dto;
using ToDo.Application.Services.Todos.Interfaces;
using ToDo.Application.Services.Users.Interfaces;
using ToDo.Domain.Entities.ToDos;
using ToDo.Domain.Entities.ToDos.Exceptions;
using ToDo.Domain.Entities.Users.Exceptions;
using ToDo.Shared;

namespace ToDo.Application.Services.Todos.Implementations
{
    public class TodoService(IToDoRepository toDoRepository, IUserService userService, 
        IDateTimeProvider dateTimeProvider) : ITodoService
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;
        private readonly IUserService _userService = userService;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        /// <summary>
        /// Mark todo as done
        /// </summary>
        /// <param name="toDoId"></param>
        /// <returns>ToItemResponse</returns>
        public async Task<TodoItemResponse> CompleteToDo(Guid toDoId)
        {
            var todo = await _toDoRepository.GetByIdAsync(toDoId);

            todo.IsCompleted = true;
            todo.CompletedAt = _dateTimeProvider.UtcNow;

            return new TodoItemResponse(await _toDoRepository.UpdateAsync(todo));  
        }

        /// <summary>
        /// Create todo item
        /// </summary>
        /// <param name="createRequest"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<TodoItemResponse> CreateTodo(CreateTodoItemRequest createRequest,string email)
        {
            var user = _userService.GetUserByEmail(email);

            return user == null
                ? throw new UserNotFoundException()
                : await AddToDoItem(createRequest.Description!, user.UserId,createRequest.Priority);
        }

        public   IEnumerable<TodoItemResponse> GetUserTodos(string email)
        {
            return _toDoRepository.GetAllAsync().Select(todo => new TodoItemResponse(todo));
        }
        private async Task<TodoItemResponse> AddToDoItem(string description,Guid userId,Priority priority)
        {
            if(_toDoRepository.ToDoExist(description, userId))
                throw new ToDoExistException();

            var toDoItem= await _toDoRepository.CreateAsync(new TodoItem
            {
                Description = description,
                UserId = userId,
                CreatedAt = _dateTimeProvider.UtcNow,
                Priority=priority
            });

            return new TodoItemResponse(toDoItem);
        }
    }
}
