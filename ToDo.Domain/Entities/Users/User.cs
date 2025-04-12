
namespace ToDo.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime LastLogIn { get; set; }

        public User()
        {
            LastLogIn = DateTime.UtcNow;
        }
    }
}
