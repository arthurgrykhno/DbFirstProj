using System;
using DbFirstProj.Entities;
using DbFirstProj.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Services.BusinessLogic
{
    public class RelationService : IGenericService<Relation>
    {
        private readonly RelationRepository relationRepository;
        private readonly CountryRepository countryRepository;
        private readonly AddressTypeRepository addressTypeRepository;
        private readonly CategoryRepository categoryRepository;

        public RelationService()
        {
            relationRepository = new RelationRepository();
            countryRepository = new CountryRepository();
            addressTypeRepository = new AddressTypeRepository();
            categoryRepository = new CategoryRepository();
        }

        public void CreateRelation(Relation relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");
            }

            relationRepository.Create(relation);
        }

        public void DeleteRelation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            relationRepository.Delete(id);
        }

        public void DeleteCollection(string[] ids)
        {
            if (ids.Length == 0 || ids == null)
            {
                throw new ArgumentException(nameof(ids), "Parameter must be greater than zero.");
            }

            foreach (var id in ids)
            {
                var guid = Guid.Parse(id);
                this.DeleteRelation(guid);
            }
        }

        public Relation GetRelation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            return relationRepository.Get(id);
        }

        public IEnumerable<Relation> GetAllRelations()
        {
            var relations = (List<Relation>)relationRepository.GetAll();
            var result = relations.FindAll(r => r.IsDisabled == false);

            return result;
        }

        public IEnumerable<Relation> GetSortedRelations(string sortingCondition, bool isDesc)
        {
            var relations = (List<Relation>)relationRepository.GetAll(sortingCondition, isDesc);
            var result = relations.FindAll(r => r.IsDisabled == false);

            return result;
        }

        public void UpdateRelation(Relation relation)
        {
            if (relation == null)
            {
                throw new ArgumentNullException(nameof(relation), "Parameter is null.");
            }

            relationRepository.Update(relation);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return countryRepository.GetAll();
        }

        public IEnumerable<AddressType> GetAllAdressTypes()
        {
            return addressTypeRepository.GetAll();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return (List<Category>)categoryRepository.GetAll();
        }

        public IEnumerable<Relation> GetFiltredRelations(Guid id)
        {
            return (List<Relation>)relationRepository.GetFiltredRelations(id);
        }
    }
}
