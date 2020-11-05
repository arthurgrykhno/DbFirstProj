using DbFirstProj.Entities;
using System;
using System.Collections.Generic;

namespace DbFirstProj.Services.BusinessLogic
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void CreateRelation(Relation relation);
        void DeleteRelation(Guid id);
        void DeleteCollection(string[] ids);
        void UpdateRelation(Relation relation);
        Relation GetRelation(Guid id);
        IEnumerable<Relation> GetAllRelations();
        IEnumerable<Relation> GetSortedRelations(string sortingCondition, bool isDesc);
        IEnumerable<Country> GetAllCountries();
        IEnumerable<AddressType> GetAllAdressTypes();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Relation> GetFiltredRelations(Guid id);
    }
}
