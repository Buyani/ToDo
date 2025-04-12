

using ToDo.Domain.Entities.ToDos;

namespace ToDo.Application.Dto
{
    public record CreateTodoItemRequest(string? Description,string? UserEmail ,string FirstName,string LastName,Priority Priority);
}
