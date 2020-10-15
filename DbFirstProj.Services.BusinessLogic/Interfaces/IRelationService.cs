using DbFirstProj.Entities;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public interface IRelationService
    {
        IEnumerable<TblRelation> GetAll();

        TblRelation Get(int id);

        void Create(TblRelation relation);

        void Delete(int id);

        void Update(TblRelation relation);

    }
}
