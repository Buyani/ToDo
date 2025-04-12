
using ToDo.Application.Abstractions.ToDos;
using ToDo.Application.Dto;
using ToDo.Application.Services.Todos.Interfaces;
using ToDo.Application.Services.Users.Interfaces;
using ToDo.Domain.Entities.ToDos;
using ToDo.Domain.Entities.ToDos.Exceptions;
using ToDo.Shared;

namespace ToDo.Application.Services.Todos.Implementations
{
    public class TodoService(IToDoRepository toDoRepository, IUserService userService, 
        IDateTimeProvider dateTimeProvider) : ITodoService
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;
        private readonly IUserService _userService = userService;
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        public async Task<TodoItemResponse> CreateTodo(CreateTodoItemRequest createRequest)
        {
            var user = _userService.GetUserByEmail(createRequest.UserEmail!);

            user ??= await _userService.CreateUser(new CreateUserRequest(createRequest.FirstName, 
                createRequest.LastName, createRequest.UserEmail));

            return  await AddToDoItem(createRequest.Description!, user.UserId,createRequest.Priority);
        }

        public   IEnumerable<TodoItemResponse> GetUserTodos(string email)
        {
            return _toDoRepository.GetAllAsync().Select(todo => new TodoItemResponse(todo));
        }
        private async Task<TodoItemResponse> AddToDoItem(string description,Guid userId,Priority priority)
        {
            var existingToDo = _toDoRepository.ToDoExist(description,userId);

            if(existingToDo)
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
