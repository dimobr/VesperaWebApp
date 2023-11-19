using Microsoft.EntityFrameworkCore;
using VesperaWebApp.AppDbContext;
using VesperaWebApp.Models;

namespace VesperaWebApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly ApplicationDbContext _appDbContext;

        public Repository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity is not null)
            { 
                return entity; 
            }
            else
            {
                throw new NullReferenceException($"{nameof(entity)} could not be found.");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _appDbContext.Set<TEntity>().ToListAsync();

            if (entities.Any())
            {
                return entities;
            }
            else 
            {
                throw new NullReferenceException();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity is not null)
            {
                await _appDbContext.Set<TEntity>().AddAsync(entity);
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity is not null)
            {
                _appDbContext.Set<TEntity>().Update(entity);
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _appDbContext.Set<TEntity>().Remove(entity);
            }
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity is not null)
            {
                _appDbContext.Set<TEntity>().Remove(entity);
            }
            await _appDbContext.SaveChangesAsync();
        }
    }
}
