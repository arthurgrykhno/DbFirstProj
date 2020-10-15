using DbFirstProj.Entities;
using DbFirstProj.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public class RelationAddressService : IGenericService<RelationAddress>
    {
        private RelationAddressRepository repository;

        public RelationAddressService()
        {
            this.repository = new RelationAddressRepository();
        }

        public void Create(RelationAddress relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");
            }

            repository.Create(relation);
        }

        public void Delete(int id)
        {
            if (id >= 0)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            repository.Delete(id);
        }

        public RelationAddress Get(int id)
        {
            if (id >= 0)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            return repository.Get(id);
        }

        public IEnumerable<RelationAddress> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(RelationAddress relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");
            }

            repository.Update(relation);
        }
    }
}
