using DbFirstProj.Entities;
using System.Collections.Generic;

namespace DbFirstProj.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Create(TEntity relation);

        void Delete(int id);

        void Update(TEntity relation);
    }
}
