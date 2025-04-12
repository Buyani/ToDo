using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.ToDos;
using ToDo.Domain.Entities.Users;

namespace ToDo.Infrastructure.DataBase.EntityConfigurations
{
    internal sealed class ToDoConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<User>().WithMany().HasForeignKey(t => t.UserId);
        }
    }
}
