using Domain.Base;
using Domain.Exceptions;

namespace Domain.FluentInterface
{
    /// <summary>
    /// Helper class used to provide a fluent interface for moving objects from container to container
    /// </summary>
    public class PutOperator
    {
        /// <summary>
        /// The avatar performing the action
        /// </summary>
        private readonly Avatar _avatar;

        /// <summary>
        /// The object that will be moved
        /// </summary>
        private readonly WorldObject _objectToMove;

        /// <summary>
        /// Initializes a new instance of the PutOperator class.
        /// </summary>
        /// <param name="avatar">The avatar performing the action</param>
        /// <param name="objectToMove">The object that will be moved</param>
        public PutOperator(Avatar avatar, WorldObject objectToMove)
        {
            _avatar = avatar;
            _objectToMove = objectToMove;
        }

        /// <summary>
        /// Completes the transfer of an object to a new container
        /// </summary>
        /// <param name="containerObject">The container to which the object will be transferred</param>
        public void In(ContainerObject containerObject)
        {
            if (!ReferenceEquals(_avatar, _objectToMove.ParentContainerObject))
            {
                throw new LawsOfPhysicsViolationException("You do not have telekinesis! You need to pick the item up first.");
            }

            _avatar.Transfer(_objectToMove).To(containerObject);
        }
    }
}