using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dto;
using ToDo.Application.Services.Todos.Interfaces;
using ToDo.Domain.Entities.ToDos.Exceptions;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ILogger<ToDoController> _logger;
    private readonly ITodoService _todoService;

    public ToDoController(ILogger<ToDoController> logger, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    [HttpGet(Name = "Todos")]
    public IEnumerable<TodoItemResponse> Get(string email)
    {
        return _todoService.GetUserTodos(email);
    }

    [HttpPost(Name = "Todos")]
    public async Task<IActionResult> Post(CreateTodoItemRequest createTodoItemRequest)
    {
        var userEmail = "buyanimhlongo@gmail.com";
        try
        {
            var response= await _todoService.CreateTodo(createTodoItemRequest,userEmail);

            return Ok(response);
        }
        catch (ToDoExistException ex)
        {
            return Conflict(new
            {
                error = ex.Message
            });
        }
        catch (Exception ex)
        {
            // Optional: generic fallback handler
            return StatusCode(500, new
            {
                error = "An unexpected error occurred.",
                details = ex.Message
            });
        }

    }

    [HttpPut(Name = "Todos")]
    public async Task<IActionResult> Complete(Guid toDoId)
    {
        var userEmail = "buyanimhlongo@gmail.com";
        try
        {
            var response = await _todoService.CompleteToDo(toDoId);
           
            return Ok(response);
        }
        catch (ToDoExistException ex)
        {
            return Conflict(new
            {
                error = ex.Message
            });
        }
        catch (Exception ex)
        {
            // Optional: generic fallback handler
            return StatusCode(500, new
            {
                error = "An unexpected error occurred.",
                details = ex.Message
            });
        }

    }
}
