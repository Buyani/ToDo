

using ToDo.Domain.Entities.ToDos;

namespace ToDo.Application.Dto
{
    public record CreateTodoItemRequest(string? Description,Priority Priority);
}
