

using ToDo.Domain.Entities.ToDos;

namespace ToDo.Application.Dto
{
    public class TodoItemResponse
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string Priority { get; set; }

        public TodoItemResponse(TodoItem todo ) {
        
            Description = todo.Description;
            IsCompleted = todo.IsCompleted;
            UserId = todo.UserId;
            Priority = todo.Priority.ToString();
            CompletedAt = todo.CompletedAt;

        }
    }
}
