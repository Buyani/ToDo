

namespace ToDo.Shared
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

}
