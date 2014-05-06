using System;
using Domain.Exceptions;

namespace Domain.Base
{
    /// <summary>
    /// Represents an item in the virtual world of dishes and animals.
    /// </summary>
    public abstract class WorldObject : IWorldObject
    {
        /// <summary>
        /// Overall size of the object (varies for derived objects)
        /// </summary>
        public abstract int Size { get; }

        /// <summary>
        /// An internally-generated ID for this item, which ensures that
        /// an object in the world can always be tracked uniquely.
        /// It is not persisted to a backing store, and has no implicit meaning.
        /// </summary>
        public Guid ObjectId { get; private set; }

        /// <summary>
        /// Internal record of the immediate container this item is in.  
        /// Objects that are not in a container float in "limbo".
        /// </summary>
        public ContainerObject ParentContainerObject { get; internal set; }

        /// <summary>
        /// Creates an instance of WorldItem.  Called by derived classes.
        /// </summary>
        protected WorldObject()
        {
            ObjectId = Guid.NewGuid();
        }

        /// <summary>
        /// Transfers an object from its parent container to this one.
        /// Used internally by domain objects to maintain proper state.
        /// </summary>
        /// <param name="objectToTransfer">The object to transfer into this container</param>
        /// <remarks>
        /// As this operation can really make a mess of the domain state, it is not accessible outside the domain assembly
        /// </remarks>
        internal TransferOperator Transfer(WorldObject objectToTransfer)
        {
            return new TransferOperator(objectToTransfer);
        }

        /// <summary>
        /// Helper class used to provide a fluent interface for moving objects from container to container
        /// </summary>
        /// <remarks>
        /// This needs to be a nested class because it needs to directly manipulate the internal container state.
        /// </remarks>
        internal class TransferOperator
        {
            private readonly WorldObject _objectToMove;

            /// <summary>
            /// Initializes a new instance of the TransferOperator class.
            /// </summary>
            public TransferOperator(WorldObject objectToMove)
            {
                _objectToMove = objectToMove;
            }

            /// <summary>
            /// Completes the transfer of an object to a new container
            /// </summary>
            /// <param name="newContainerObject">The container to which the object will be transferred</param>
            public void To(ContainerObject newContainerObject)
            {
                ContainerObject oldContainerObject = _objectToMove.ParentContainerObject;

                if (ReferenceEquals(oldContainerObject, newContainerObject) || (newContainerObject == null && oldContainerObject == null))
                {
                    throw new LawsOfPhysicsViolationException("Can't transfer this item to the same container more than once.");
                }

                if (oldContainerObject != null)
                {
                    if (oldContainerObject is ICanBeLocked)
                    {
                        ICanBeLocked lockableContainer = oldContainerObject as ICanBeLocked;
                        if (lockableContainer.IsLocked)
                        {
                            throw new LockedException("The item you want to pick up is locked inside a container.  Sorry!");
                        }
                    }
                    oldContainerObject.InternalContainer.RemoveTheseObjects(x => x.ObjectId == _objectToMove.ObjectId);
                }

                _objectToMove.ParentContainerObject = newContainerObject;
                if (newContainerObject != null)
                {
                    newContainerObject.InternalContainer.AddObject(_objectToMove);
                }
            }

            /// <summary>
            /// Completes the transfer of the object to limbo (basically annihilating it)
            /// </summary>
            public void ToLimbo()
            {
                ContainerObject oldContainerObject = _objectToMove.ParentContainerObject;
                if (oldContainerObject != null)
                {
                    oldContainerObject.InternalContainer.RemoveTheseObjects(x => x.ObjectId == _objectToMove.ObjectId);
                }
                _objectToMove.ParentContainerObject = null;
            }
        }
    }
}