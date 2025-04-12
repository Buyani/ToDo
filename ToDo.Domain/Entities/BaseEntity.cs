
using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
