using System;
using System.Collections.Generic;

namespace DbFirstProj.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Method for getting all entities from database.
        /// </summary>
        /// <param name="sortingCondition">
        /// Using when we need to get collection with sorting condition.
        /// </param>
        /// <param name="isDesc">
        /// Set ordering by descending when false, ascending when true.
        /// </param>
        /// <returns>
        /// Collection TEntity type.
        /// </returns>
        IEnumerable<TEntity> GetAll(string sortingCondition, bool isDesc);

        /// <summary>
        /// Get one entity from database.
        /// </summary>
        /// <param name="id">
        /// Uniqueidentifier
        /// </param>
        /// <returns>
        /// One entity TEntity type
        /// </returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Create and add entity to database.
        /// </summary>
        /// <param name="relation">
        /// Item for adding to database.
        /// </param>
        void Create(TEntity relation);

        /// <summary>
        /// Getting relation from database and set "isDisabled" field to false.
        /// </summary>
        /// <param name="id">
        /// Uniqueidentifier
        /// </param>
        void Delete(Guid id);

        /// <summary>
        /// Find and update relation in database.
        /// </summary>
        /// <param name="relation">
        /// Entity with TEntity type.
        /// </param>
        void Update(TEntity relation);
    }
}
