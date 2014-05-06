using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;

namespace Domain.Base
{
    /// <summary>
    /// Defines operations and properties need for an object that that can hold other objects.
    /// </summary>
    /// <remarks>
    /// This object demonstrates some fairly advanced patterns for encapsulation. The goals for said encapsulation are as follows:
    /// 1) It should not be possible for anyone outside of a ContainerObject (or even classes derived from ContainerObject) to directly manipulate the storage mechanism in unsupported ways
    /// 2) It should not be possible to inherit from ContainerObject in a class outside the Domain assembly.  The Domain assembly sets the boundary for Domain behavior (like the concept of Containers)
    /// 3) It should be possible to store all kinds of domain objects in all sorts of containers and transfer easily between them.
    /// 4) This class should have as small of a surface area as possible
    /// </remarks>
    public abstract class ContainerObject : WorldObject
    {
        /// <summary>
        /// Mechanism that manages this object's contents.
        /// </summary>
        /// <remarks>
        /// This is built via composition so that the inner workings of this mechanism are totally 
        /// inaccessible outside the domain model assembly.
        /// </remarks>
        internal Container InternalContainer { get; private set; }

        /// <summary>
        /// Accessor for the objects in the container
        /// </summary>
        public IEnumerable<WorldObject> Contents
        {
            get
            {
                return InternalContainer.Contents;
            }
        }

        /// <summary>
        /// Returns the current capacity of the container
        /// </summary>
        public int RemainingCapacity
        {
            get { return InternalContainer.StorageCapacityRemaining; }
        }

        /// <summary>
        /// Determines if the current object is empty
        /// </summary>
        /// <returns>True if empty, else false</returns>
        public bool IsEmpty
        {
            get
            {
                return InternalContainer.IsEmpty;
            }
        }

        /// <summary>
        /// Determines if the current object is full
        /// </summary>
        /// <returns>True if full, else false</returns>
        public bool IsFull
        {
            get
            {
                return InternalContainer.IsFull;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ContainerObject class.
        /// </summary>
        /// <param name="maxStorageCapacity">Indicates the max storage limit for this container</param>
        /// <remarks>
        /// This constructor is internal, because only domain objects in the same assembly should use it.
        /// </remarks>
        internal ContainerObject(int maxStorageCapacity)
        {
            InternalContainer = new Container(maxStorageCapacity);
        }

        /// <summary>
        /// Implements the operations needs to support the mechanic of "containers"
        /// in the domain sample universe.  A container is an object that contains other objects.
        /// It has a maximum capacity, and an item can be in only one immediate container at a time (though you can have nested containers).
        /// </summary>
        internal class Container
        {
            /// <summary>
            /// Indicates the max storage limit for this container
            /// </summary>
            private readonly int _maxStorageCapacity;

            /// <summary>
            /// List of the contents of the container
            /// </summary>
            private readonly List<WorldObject> _contents = new List<WorldObject>();

            /// <summary>
            /// Accessor for the objects in the container
            /// </summary>
            public IEnumerable<WorldObject> Contents
            {
                get
                {
                    return _contents;
                }
            }

            /// <summary>
            /// Calculates how much space is remaining in the container
            /// </summary>
            public int StorageCapacityRemaining
            {
                get
                {
                    return _maxStorageCapacity - _contents.Sum(x => x.Size);
                }
            }

            /// <summary>
            /// Determines if the container is empty
            /// </summary>
            /// <returns>True if empty, else false</returns>
            public bool IsEmpty
            {
                get
                {
                    return StorageCapacityRemaining == _maxStorageCapacity;
                }
            }

            /// <summary>
            /// Determines if the container is full
            /// </summary>
            /// <returns>True if full, else false</returns>
            public bool IsFull
            {
                get
                {
                    return StorageCapacityRemaining == 0;
                }
            }

            /// <summary>
            /// Initializes a new instance of the InternalContainer class.
            /// </summary>
            internal Container(int maxStorageCapacity)
            {
                _maxStorageCapacity = maxStorageCapacity;
            }

            /// <summary>
            /// Adds a single object
            /// </summary>
            /// <param name="objectToAdd">The object to add</param>
            public void AddObject(WorldObject objectToAdd)
            {
                if (objectToAdd.Size > StorageCapacityRemaining)
                {
                    throw new CapacityException(string.Format("The supplied item was '{0}' in size, but there was only '{1}' left to store it.", objectToAdd.Size, StorageCapacityRemaining));
                }
                _contents.Add(objectToAdd);
            }

            /// <summary>
            /// Adds multiple objects to the container
            /// </summary>
            /// <param name="objectsToAdd">The objects to add</param>
            public void AddObjects(IEnumerable<WorldObject> objectsToAdd)
            {
                foreach (var item in objectsToAdd)
                {
                    AddObject(item);
                }
            }

            /// <summary>
            /// Removes the given objects from the container
            /// </summary>
            /// <param name="predicate">Filter condition for removing objects</param>
            /// <returns>A list of the removed objects</returns>
            public IEnumerable<WorldObject> RemoveTheseObjects(Func<WorldObject, bool> predicate)
            {
                List<WorldObject> removedObjects = new List<WorldObject>();
                WorldObject[] objectsToRemove = _contents.Where(predicate).ToArray();
                foreach (var item in objectsToRemove)
                {
                    if (_contents.Remove(item))
                    {
                        removedObjects.Add(item);
                    }
                }
                return removedObjects;
            }

            /// <summary>
            /// Removes all objects from the container
            /// </summary>
            /// <returns>A list of the removed objects</returns>
            public IEnumerable<WorldObject> RemoveAllObjects()
            {
                return RemoveTheseObjects(x => true);
            }
        }
    }
}