using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared;

namespace ToDo.Domain.Entities.Users
{
    public static class UserErros
    {
        public static Error NotFound(string email) => Error.NotFound(
    "Users.NotFound",
    $"The user with the Id = '{email}' was not found");

        public static Error Unauthorized() => Error.Failure(
            "Users.Unauthorized",
            "You are not authorized to perform this action.");

        public static readonly Error NotFoundByEmail = Error.NotFound(
            "Users.NotFoundByEmail",
            "The user with the specified email was not found");

        public static readonly Error EmailNotUnique = Error.Conflict(
            "Users.EmailNotUnique",
            "The provided email is not unique");
        public static string UserNotFound = "User not found";
    }
}
