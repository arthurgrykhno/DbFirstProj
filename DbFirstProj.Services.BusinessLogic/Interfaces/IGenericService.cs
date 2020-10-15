using DbFirstProj.Entities;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Create(TEntity relation);

        void Delete(int id);

        void Update(TEntity relation);
    }
}
