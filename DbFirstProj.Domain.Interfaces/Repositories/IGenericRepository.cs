using DbFirstProj.Entities;
using System;
using System.Collections.Generic;

namespace DbFirstProj.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid id);

        void Create(TEntity relation);

        void Delete(Guid id);

        void Update(TEntity relation);
    }
}
