using DbFirstProj.Entities;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public interface IRelationAddressService
    {
        IEnumerable<TblRelationAddress> GetAll();

        TblRelationAddress Get(int id);

        void Create(TblRelationAddress relation);

        void Delete(int id);

        void Update(TblRelationAddress relation);
    }
}
