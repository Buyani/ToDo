using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Abstractions.Data;
using ToDo.Application.Abstractions.ToDos;
using ToDo.Application.Abstractions.Users;
using ToDo.Infrastructure.DataBase;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Time;
using ToDo.Shared;


namespace ToDo.Infrastructure
{
    public static class DependencyInjection
    {
        public  static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("ToDoConnectionString");

            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IToDoRepository, TodoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
