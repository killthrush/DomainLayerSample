using System;

namespace Domain.Base
{
    /// <summary>
    /// Defines operations and properties for objects in the domain
    /// </summary>
    public interface IWorldObject
    {
        /// <summary>
        /// An internally-generated ID for this item.  This is not visible to the application,
        /// but ensures that every item can be tracked uniquely.
        /// </summary>
        Guid ObjectId { get; }

        /// <summary>
        /// Overall size of the object (varies for different implementations)
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Internal record of the immediate container this item is in.  
        /// Objects that are not in a container float in "limbo".
        /// </summary>
        ContainerObject ParentContainerObject { get; }
    }
}