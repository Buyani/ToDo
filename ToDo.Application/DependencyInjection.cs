using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Services.Todos.Implementations;
using ToDo.Application.Services.Todos.Interfaces;
using ToDo.Application.Services.Users.Implementations;
using ToDo.Application.Services.Users.Interfaces;

namespace ToDo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddToDoAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>()
                .AddScoped<ITodoService, TodoService>();   
            return services;
        }
    }
}
