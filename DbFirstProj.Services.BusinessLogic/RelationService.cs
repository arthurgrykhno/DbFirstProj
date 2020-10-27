﻿using System;
using DbFirstProj.Entities;
using DbFirstProj.Infrastructure.Data;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public class RelationService /*: IGenericService<Relation>*/
    {
        private RelationRepository relationRepository;
        private RelationAddressRepository addressRepository;
        private CountryRepository countryRepository;
        private AddressTypeRepository addressTypeRepository;

        public RelationService()
        {
            relationRepository = new RelationRepository();
            addressRepository = new RelationAddressRepository();
            countryRepository = new CountryRepository();
            addressTypeRepository = new AddressTypeRepository();
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
            List<Relation> relations = (List<Relation>)relationRepository.GetAll();
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

        public void CreateAddress(RelationAddress relationAddress)
        {
            if (relationAddress == null)
            {
                throw new ArgumentNullException(nameof(relationAddress), "Parameter is null.");
            }

            addressRepository.Create(relationAddress);
        }

        public void DeleteAddress(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            relationRepository.Delete(id);
        }

        public RelationAddress GetAddress(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id), "Parameter must be greater than zero.");
            }

            return addressRepository.Get(id);
        }

        public IEnumerable<RelationAddress> GetAllAddresses()
        {
            return addressRepository.GetAll();
        }

        public void UpdateAddress(RelationAddress relationAddress)
        {
            if (relationAddress == null)
            {
                throw new ArgumentNullException(nameof(relationAddress), "Parameter is null.");
            }

            addressRepository.Update(relationAddress);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return countryRepository.GetAll();
        }

        public IEnumerable<AddressType> GetAllAdressTypes()
        {
            return addressTypeRepository.GetAll();
        }
    }
}
