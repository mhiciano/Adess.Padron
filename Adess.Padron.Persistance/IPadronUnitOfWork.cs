using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adess.Padron.Domain;

namespace Adess.Padron.Persistance
{
    public interface IPadronUnitOfWork
    {
        IRepository<TEntity, TPrimaryKey> RepositoryFor<TEntity, TPrimaryKey>() where TEntity : AEntity<TPrimaryKey>;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
