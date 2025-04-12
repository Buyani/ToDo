

namespace ToDo.Application.Abstractions.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChengesAsync();
    }
}
