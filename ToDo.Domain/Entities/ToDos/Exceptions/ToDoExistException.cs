
using System.Net;

namespace ToDo.Domain.Entities.ToDos.Exceptions
{
    public class ToDoExistException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;

        public ToDoExistException()
            : base(ToDoErrors.SamToDoExist)
        {
        }

        public ToDoExistException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
