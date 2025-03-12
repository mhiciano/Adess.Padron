using System.Linq.Expressions;
using Adess.Padron.Domain;
using Microsoft.EntityFrameworkCore;

namespace Adess.Padron.Persistance
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : AEntity<TPrimaryKey>
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            var result = _dbContext.Set<TEntity>().Any(expression);
            return result;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _dbContext.Set<TEntity>().AnyAsync(expression);
            return result;
        }

        public void Attach(TEntity entity)
        {
            _dbContext.Attach<TEntity>(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true)
        {
            IQueryable<TEntity> entities;

            var entity = _dbContext.Set<TEntity>();

            if (asNoTracking)
            {
                entities = entity.Where(expression).AsNoTracking();

                return entities;
            }

            entities = entity.Where(expression);

            return entities;
        }

        public async Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true)
        {
            List<TEntity> entities;

            var entity = _dbContext.Set<TEntity>();

            if (asNoTracking)
            {
                entities = await entity.Where(expression).AsNoTracking().ToListAsync();

                return entities;
            }

            entities = await entity.Where(expression).ToListAsync();

            return entities;
        }

        public async Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true)
        {
            var entity = _dbContext.Set<TEntity>();

            if (asNoTracking)
            {
                return await entity.AsNoTracking().FirstOrDefaultAsync(expression);

            }

            return await entity.FirstOrDefaultAsync(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await GetAll().AsNoTracking().ToListAsync();
            }

            return await GetAll().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public TEntity? Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
