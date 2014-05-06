using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IWideWorldRepository
    {
        /// <summary>
        /// Saves the state of a given domain entity object
        /// </summary>
        /// <param name="entity">The entity to save</param>
        void Persist(Dishwasher entity);

        /// <summary>
        /// Saves the state of a set of domain entity object
        /// </summary>
        /// <param name="entities">The entity to save</param>
        void Persist(IEnumerable<Dishwasher> entities);

        /// <summary>
        /// Finds an entity by ID
        /// </summary>
        /// <param name="id">The ID of the entity to return</param>
        /// <returns>The entity reference, or null if a match was not found</returns>
        Dishwasher FindById(int id);

        /// <summary>
        /// Finds an entity by an arbitrary query
        /// </summary>
        /// <param name="query">A query implementation to execute</param>
        /// <returns>A list of matching entity references, or an empty list if a match was not found</returns>
        IEnumerable<Dishwasher> Find(ISqlQuery query);

        /// <summary>
        /// Removes an entity from persistent storage
        /// </summary>
        /// <param name="id">The ID of the entity to delete</param>
        void Forget(int id);
    }
}