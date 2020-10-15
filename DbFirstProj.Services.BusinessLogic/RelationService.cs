using System;
using DbFirstProj.Entities;
using DbFirstProj.Infrastructure.Data;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public class RelationService : IGenericService<Relation>
    {
        private RelationRepository repository;

        public RelationService()
        {
            repository = new RelationRepository();
        }

        public void Create(Relation relation)
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

        public Relation Get(int id)
        {
            if (id >= 0)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            return repository.Get(id);
        }

        public IEnumerable<Relation> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Relation relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");
            }

            repository.Update(relation);
        }
    }
}
