using DbFirstProj.Entities;
using DbFirstProj.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFirstProj.Services.BusinessLogic
{
    public class RelationAddressService : IRelationAddressService
    {
        private RelationAddressRepository repository;
        public RelationAddressService()
        {
            this.repository = new RelationAddressRepository();
        }
        public void Create(TblRelationAddress relation)
        {
            if (relation == null)
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");

            repository.Create(relation);
        }

        public void Delete(int id)
        {
            if (id >= 0)
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");

            repository.Delete(id);
        }

        public TblRelationAddress Get(int id)
        {
            if (id >= 0)
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");

            return repository.Get(id);
        }

        public IEnumerable<TblRelationAddress> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(TblRelationAddress relation)
        {
            repository.Update(relation);
        }
    }
}
