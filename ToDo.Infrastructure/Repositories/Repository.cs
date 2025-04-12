
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions.Data;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.DataBase;

namespace ToDo.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await  _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public  async Task<bool> DeleteAsync(Guid id)
        {
            var searchResult = await GetByIdAsync(id);

            if(searchResult !=null)
            {
                await _context.Set<TEntity>().ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return _dbSet;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var searchResult= await _dbSet.FindAsync(id);

            if(searchResult !=null)
            {
                return searchResult;
            }

            return default!;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
