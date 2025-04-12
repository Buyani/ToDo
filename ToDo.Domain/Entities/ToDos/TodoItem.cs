namespace ToDo.Domain.Entities.ToDos
{
    public class TodoItem : BaseEntity
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }    
        public DateTime? CompletedAt { get; set; }
        public Priority Priority { get; set; }
    }
}
