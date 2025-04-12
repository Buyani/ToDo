

using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAllAsync();
    }
}
