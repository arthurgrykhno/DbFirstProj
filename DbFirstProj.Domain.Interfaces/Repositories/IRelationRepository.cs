using DbFirstProj.Entities;
using System.Collections.Generic;

namespace DbFirstProj.Domain.Interfaces.Repositories
{
    public interface IRelationRepository
    {
        IEnumerable<TblRelation> GetAll();

        TblRelation Get(int id);

        void Create(TblRelation relation);

        void Delete(int id);

        void Update(TblRelation relation);
    }
}
