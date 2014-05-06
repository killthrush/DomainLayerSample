using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain.FluentInterface
{
    /// <summary>
    /// Helper class used to provide a fluent interface for dispensing beverages
    /// </summary>
    public class DispenseBeerOperator
    {
        /// <summary>
        /// The fridge that will dispense the beer
        /// </summary>
        private readonly Fridge _fridge;

        /// <summary>
        /// The avatar performing the action
        /// </summary>
        private readonly Avatar _avatar;

        /// <summary>
        /// Initializes a new instance of the DispenseBeerOperator class.
        /// </summary>
        /// <param name="avatar">The avatar performing the action</param>
        /// <param name="fridge">The fridge that will dispense the beer</param>
        public DispenseBeerOperator(Avatar avatar, Fridge fridge)
        {
            _fridge = fridge;
            _avatar = avatar;
        }

        /// <summary>
        /// Attempts to fill the container with beer
        /// </summary>
        /// <param name="container"></param>
        public void Into(ContainerObject container)
        {
            IEnumerable<Guid> idsForObjectsBeingHeld = _avatar.Contents.Select(x => x.ObjectId);
            IEnumerable<Guid> containerObjectIds = new[] { container }.Select(x => x.ObjectId);
            bool tryingToUseContainerNotBeingHeld = containerObjectIds.Except(idsForObjectsBeingHeld).Any();

            if (tryingToUseContainerNotBeingHeld)
            {
                throw new LawsOfPhysicsViolationException("You do not have telekinesis! You need to pick the item(s) up first.");
            }

            _fridge.DispenseBeerInto(container);
        }
    }
}