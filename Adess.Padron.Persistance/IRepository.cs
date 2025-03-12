using System.Linq.Expressions;
using Adess.Padron.Domain;

namespace Adess.Padron.Persistance
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : AEntity<TPrimaryKey>
    {
        Task<TEntity?> GetAsync(int id);
        TEntity? Get(int id);
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true);
        Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true);
        Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression, bool asNoTracking = true);
        bool Any(Expression<Func<TEntity, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);
        List<TEntity> AddRange(List<TEntity> entities);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void Attach(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
    }
}
