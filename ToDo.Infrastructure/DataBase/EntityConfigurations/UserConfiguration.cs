using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.Users;

namespace ToDo.Infrastructure.DataBase.EntityConfigurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id);
           builder.HasIndex(p=> p.Email).IsUnique();
        }
    }
}
