using System.Collections.Generic;

namespace Domain.Repository
{
    /// <summary>
    /// Backing store for the world and the objects it contains
    /// </summary>
    public class WideWorldRepository : IWideWorldRepository
    {
        /// <summary>
        /// Saves the state of a given domain entity object
        /// </summary>
        /// <param name="entity">The entity to save</param>
        public void Persist(Dishwasher entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the state of a set of domain entity object
        /// </summary>
        /// <param name="entities">The entity to save</param>
        public void Persist(IEnumerable<Dishwasher> entities)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Finds an entity by ID
        /// </summary>
        /// <param name="id">The ID of the entity to return</param>
        /// <returns>The entity reference, or null if a match was not found</returns>
        public Dishwasher FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Finds an entity by an arbitrary query
        /// </summary>
        /// <param name="query">A query implementation to execute</param>
        /// <returns>A list of matching entity references, or an empty list if a match was not found</returns>
        public IEnumerable<Dishwasher> Find(ISqlQuery query)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes an entity from persistent storage
        /// </summary>
        /// <param name="id">The ID of the entity to delete</param>
        public void Forget(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
