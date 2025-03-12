using Adess.Padron.Domain;

namespace Adess.Padron.Persistance;

public class PadronUnitOfWork : IPadronUnitOfWork
{
    private readonly PadronDbContext _dbContext;

    public PadronUnitOfWork(PadronDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IRepository<TEntity, TPrimaryKey> RepositoryFor<TEntity, TPrimaryKey>() where TEntity : AEntity<TPrimaryKey>
    {
        return new Repository<TEntity, TPrimaryKey>(_dbContext);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
